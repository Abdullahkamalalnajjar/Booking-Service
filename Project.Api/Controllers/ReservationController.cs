using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Reservations.Command.Models;
using Project.Core.Features.VerificationRequests.Commands.Models;

namespace Project.Api.Controllers
{
    public class ReservationController : AppBaseController
    {
        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReservation([FromForm] CreateReservationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
