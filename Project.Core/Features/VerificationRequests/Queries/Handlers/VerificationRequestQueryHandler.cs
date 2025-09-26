using Project.Core.Features.VerificationRequests.Queries.Models;
using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.VerificationRequests.Queries.Handlers
{
    public class VerificationRequestQueryHandler(IVerificationRequestService verificationRequestService) : ResponseHandler,
            IRequestHandler<GetAllVerificationRequestQuery, Response<IEnumerable<VerificationRequestDto>>>,
            IRequestHandler<GetVerificationRequesByServiceIdQuery, Response<VerificationRequestDto>>


    {
        private readonly IVerificationRequestService _verificationRequestService = verificationRequestService;

        public async Task<Response<IEnumerable<VerificationRequestDto>>> Handle(GetAllVerificationRequestQuery request, CancellationToken cancellationToken)
        {
            var verificationRequest= await _verificationRequestService.GetAllAsync();
            return Success(verificationRequest);
         
        }

        public async Task<Response<VerificationRequestDto>> Handle(GetVerificationRequesByServiceIdQuery request, CancellationToken cancellationToken)
        {
            var verificationRequest = await  _verificationRequestService.GetByServiceIdAsync(request.Id);
            if (verificationRequest == null)
           return NotFound<VerificationRequestDto>("Verification Request Not found");
            return Success(verificationRequest);
        }
    }
}
