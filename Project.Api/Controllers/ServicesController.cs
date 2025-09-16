using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Services.Commands.Models;
using Project.Core.Features.Services.Queries.Models;

namespace Project.Api.Controllers
{

    public class ServicesController : AppBaseController
    {
        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete("DeleteServiceById")]
        public async Task<IActionResult> DeleteService([FromQuery] DeleteServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var response = await Mediator.Send(new GetAllServicesQuery());
            return NewResult(response);
        }
        [HttpGet("GetServicesByCategoryName")]
        public async Task<IActionResult> GetServicesByCategoryName([FromQuery] GetServicesByCategoryNameQuery query )
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById([FromQuery] GetServiceByIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
