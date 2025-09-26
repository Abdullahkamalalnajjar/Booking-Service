using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Queries.Models
{
    public class GetVerificationRequesByServiceIdQuery : IRequest<Response<VerificationRequestDto>>
    {
        public int Id { get; set; }

    }
}
