using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Dtos
{
    public class SendMessageRequest
    {
        public int ConversationId { get; set; }
        public string SenderId { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
