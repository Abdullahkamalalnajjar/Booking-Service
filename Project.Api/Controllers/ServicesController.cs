using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Services.Commands.Models;
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
    }
}
