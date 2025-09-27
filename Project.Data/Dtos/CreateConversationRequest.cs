using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Dtos
{
     public class CreateConversationRequest
    {
        public string ClientId { get; set; } = null!;
        public string ServiceOwnerId { get; set; } = null!;
    }

}
