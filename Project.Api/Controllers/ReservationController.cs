using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Reservations.Command.Models;
using Project.Core.Features.Reservations.Queries.Models;
using Project.Data.AppMetaData;

namespace Project.Api.Controllers
{
    public class ReservationController : AppBaseController
    {
        [HttpPost(Router.ReservationRouting.Create)]
        public async Task<IActionResult> CreateReservation([FromForm] CreateReservationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.ReservationRouting.Edit)]
        public async Task<IActionResult> UpdateReservation([FromForm] UpdateReservationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ReservationRouting.Delete)]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var response = await Mediator.Send(new DeleteReservationCommand(id));
            return NewResult(response);
        }

        [HttpGet(Router.ReservationRouting.GetById)]
        public async Task<IActionResult> GetReservationById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetReservationByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.ReservationRouting.List)]
        public async Task<IActionResult> GetAllReservations()
        {
            var response = await Mediator.Send(new GetAllReservations());
            return NewResult(response);
        }

        [HttpGet(Router.ReservationRouting.GetReservationsForClient)]
        public async Task<IActionResult> GetReservationsForClient([FromRoute] string clientId)
        {
            var response = await Mediator.Send(new GetClientReservationsQuery(clientId));
            return NewResult(response);
        }

    }
}
