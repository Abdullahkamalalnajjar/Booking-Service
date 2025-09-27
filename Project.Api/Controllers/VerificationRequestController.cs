using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Services.Commands.Models;
using Project.Core.Features.VerificationRequests.Commands.Models;
using Project.Core.Features.VerificationRequests.Queries.Models;

namespace Project.Api.Controllers
{
    public class VerificationRequestController : AppBaseController
    {
        [HttpPost("CreateVerificationRequest")]
        public async Task<IActionResult> CreateVerificationRequest([FromForm] CreateVerificationRequestCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("UpdateVerificationRequest")] 
        public async Task<IActionResult> UpdateVerificationRequest([FromForm] UpdateVerificationRequestCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("UpdateVerificationRequestStatus")]
        public async Task<IActionResult> UpdateVerificationRequestStatus([FromQuery] UpdateVerificationRequestStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }   
        [HttpDelete("DeleteVerificationRequest")]
        public async Task<IActionResult> DeleteVerificationRequest([FromQuery] DeleteVerificationRequestCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet ("GetVerificationRequest")]

        public  async Task <IActionResult> GetVerificationRequest()
        {
            var response =await  Mediator.Send(new GetAllVerificationRequestQuery ());
            return NewResult(response);
        }

        [HttpGet("GetVerificationRequesByServiceId")]
        public async Task<IActionResult> GetVerificationRequesByServiceId([FromQuery] GetVerificationRequesByServiceIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }      
    }
}
