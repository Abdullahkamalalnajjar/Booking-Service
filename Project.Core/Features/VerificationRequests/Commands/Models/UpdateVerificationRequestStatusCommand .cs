using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Commands.Models
{
    public class UpdateVerificationRequestStatusCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }  
        public string Status { get; set; } 
    }
}
