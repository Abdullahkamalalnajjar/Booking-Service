using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities.chat
{
    public class Conversation
    {
        public int Id { get; set; }
        public string ClientId { get; set; } = null!;
        public string ServiceOwnerId { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
