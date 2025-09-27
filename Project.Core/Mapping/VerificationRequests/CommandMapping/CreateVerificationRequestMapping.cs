using Microsoft.AspNetCore.Http;
using Project.Core.Features.Services.Commands.Models;
using Project.Core.Features.VerificationRequests.Commands.Models;
using Project.Data.Entities.verifyRequst;


namespace Project.Core.Mapping.VerificationRequests
{
    public partial class VerificationRequestProfile : Profile
    {
        public void CreateVerificationRequestMapping()
        {
            CreateMap<CreateVerificationRequestCommand, VerificationRequest>();
              

        }
    }
}
