using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Services.Commands.Models;
using Project.Core.Features.Services.Queries.Models;
using Project.Core.Features.Users.Commands.Models;

namespace Project.Api.Controllers
{

    public class ServicesController : AppBaseController
    {
        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService([FromQuery] CreateServiceCommand command)
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

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById([FromQuery]GetServiceByIdQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
