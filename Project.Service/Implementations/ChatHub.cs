using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project.Data.Entities.chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Implementations
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _db;
        private readonly PresenceTracker _presence;

        public ChatHub(ApplicationDbContext db, PresenceTracker presence)
        {
            _db = db;
            _presence = presence;
        }

        public override async Task OnConnectedAsync()
        {
            var http = Context.GetHttpContext();
            var userId = http.Request.Query["userId"].ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                var becameOnline = _presence.UserConnected(userId, Context.ConnectionId);
                if (becameOnline)
                {
                    // broadcast to all that this user is online
                    await Clients.All.SendAsync("UserOnline", userId);
                }
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var http = Context.GetHttpContext();
            var userId = http.Request.Query["userId"].ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                var becameOffline = _presence.UserDisconnected(userId, Context.ConnectionId);
                if (becameOffline)
                {
                    await Clients.All.SendAsync("UserOffline", userId);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

        // join room for a conversation
        public async Task JoinConversation(int conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }

        public async Task LeaveConversation(int conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
        }

        // send message (saves to DB + broadcasts)
        public async Task SendMessage(int conversationId, string content, string senderId)
        {
            // basic validation
            var conv = await _db.Conversations.FindAsync(conversationId);
            if (conv == null)
            {
                // optional: create or throw
                throw new HubException("Conversation not found");
            }

            var msg = new Message
            {
                ConversationId = conversationId,
                SenderId = senderId,
                Content = content,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            _db.Messages.Add(msg);
            await _db.SaveChangesAsync();

            var dto = new
            {
                Id = msg.Id,
                ConversationId = msg.ConversationId,
                SenderId = msg.SenderId,
                Content = msg.Content,
                SentAt = msg.SentAt,
                IsRead = msg.IsRead,
                ReadAt = msg.ReadAt
            };

            await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", dto);
        }

        // mark unread messages as read (messages from other sender)
        public async Task MarkMessagesAsRead(int conversationId, string readerId)
        {
            var unread = await _db.Messages
                .Where(m => m.ConversationId == conversationId && !m.IsRead && m.SenderId != readerId)
                .ToListAsync();

            if (!unread.Any()) return;

            var ids = new List<int>();
            foreach (var m in unread)
            {
                m.IsRead = true;
                m.ReadAt = DateTime.UtcNow;
                ids.Add(m.Id);
            }

            await _db.SaveChangesAsync();

            // notify group that these message ids are read
            await Clients.Group(conversationId.ToString()).SendAsync("MessagesRead", conversationId, ids);
        }
    }
}
