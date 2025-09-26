using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Queries.Models
{
    public class GetAllVerificationRequestQuery :IRequest<Response<IEnumerable<VerificationRequestDto>>>
    {

    }
}
