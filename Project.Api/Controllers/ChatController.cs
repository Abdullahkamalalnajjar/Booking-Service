using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project.Data.Dtos;
using Project.Data.Entities.chat;
using Project.EF;
using Project.Service.Implementations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<ChatHub> _hub;
        private readonly PresenceTracker _presence;

        public ChatController(ApplicationDbContext db, IHubContext<ChatHub> hub, PresenceTracker presence)
        {
            _db = db;
            _hub = hub;
            _presence = presence;
        }

        [HttpPost("conversation")]
        public async Task<IActionResult> CreateConversation([FromBody] CreateConversationRequest req)
        {
            // check existing between same participants (optional)
            var existing = await _db.Conversations
                .FirstOrDefaultAsync(c => c.ClientId == req.ClientId && c.ServiceOwnerId == req.ServiceOwnerId);

            if (existing != null) return Ok(existing);

            var conv = new Conversation
            {
                ClientId = req.ClientId,
                ServiceOwnerId = req.ServiceOwnerId
            };

            _db.Conversations.Add(conv);
            await _db.SaveChangesAsync();
            return Ok(conv);
        }

        [HttpGet("conversations/{userId}")]
        public async Task<IActionResult> GetConversationsForUser(string userId)
        {
            var convs = await _db.Conversations
                .Where(c => c.ClientId == userId || c.ServiceOwnerId == userId)
                .Select(c => new {
                    c.Id,
                    c.ClientId,
                    c.ServiceOwnerId,
                    LastMessage = c.Messages.OrderByDescending(m => m.SentAt).Select(m => new {
                        m.Id,
                        m.Content,
                        m.SenderId,
                        m.SentAt,
                        m.IsRead
                    }).FirstOrDefault(),
                    // compute other party id & online flag
                    OtherPartyId = c.ClientId == userId ? c.ServiceOwnerId : c.ClientId
                })
                .ToListAsync();

            // add online flag for each (cheap)
            var withOnline = convs.Select(c => new {
                c.Id,
                c.ClientId,
                c.ServiceOwnerId,
                c.LastMessage,
                c.OtherPartyId,
                IsOtherOnline = _presence.GetConnections(c.OtherPartyId).Any()
            });

            return Ok(withOnline);
        }

        [HttpGet("messages/{conversationId}")]
        public async Task<IActionResult> GetMessages(int conversationId, int skip = 0, int take = 50)
        {
            var msgs = await _db.Messages
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.SentAt)
                .Skip(skip)
                .Take(take)
                .Select(m => new {
                    m.Id,
                    m.ConversationId,
                    m.SenderId,
                    m.Content,
                    m.SentAt,
                    m.IsRead,
                    m.ReadAt
                })
                .ToListAsync();

            return Ok(msgs);
        }

        // optional REST send (if client can't use signalR)
        [HttpPost("send")]
        public async Task<IActionResult> SendViaRest([FromBody] SendMessageRequest req)
        {
            var conv = await _db.Conversations.FindAsync(req.ConversationId);
            if (conv == null) return NotFound();

            var msg = new Message
            {
                ConversationId = req.ConversationId,
                SenderId = req.SenderId,
                Content = req.Content
            };

            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();

            var dto = new
            {
                msg.Id,
                msg.ConversationId,
                msg.SenderId,
                msg.Content,
                msg.SentAt,
                msg.IsRead
            };

            // notify via SignalR group
            await _hub.Clients.Group(req.ConversationId.ToString()).SendAsync("ReceiveMessage", dto);

            return Ok(dto);
        }
    }
 
   
  
   
}
