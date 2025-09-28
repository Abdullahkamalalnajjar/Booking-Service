using Project.Core.Features.Reservations.Queries.Models;

namespace Project.Core.Features.Reservations.Queries.Handler
{
    public class ReservationQueryHandler(IReservationService reservationService) : ResponseHandler,
        IRequestHandler<GetReservationByIdQuery, Response<ReservationDto>>,
        IRequestHandler<GetClientReservationsQuery, Response<IEnumerable<ReservationDto>>>,
        IRequestHandler<GetAllReservations, Response<IEnumerable<ReservationDto>>>

    {
        private readonly IReservationService _reservationService = reservationService;

        #region ReservationById
        public async Task<Response<ReservationDto>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(request.Id);
            if (reservation == null)
                return NotFound<ReservationDto>("Reservation not found");
            return Success(reservation);
        }

        #endregion

        #region UserReservations    
        public async Task<Response<IEnumerable<ReservationDto>>> Handle(GetClientReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetClientReservationsAsync(request.ClientId);
            if (reservations == null || !reservations.Any())
                return NotFound<IEnumerable<ReservationDto>>("No reservations found for this user");
            return Success(reservations);
        }
        #endregion

        #region AllReservations
        public async Task<Response<IEnumerable<ReservationDto>>> Handle(GetAllReservations request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            if (reservations == null || !reservations.Any())
                return NotFound<IEnumerable<ReservationDto>>("No reservations found");
            return Success(reservations);
        }
        #endregion



    }
}
