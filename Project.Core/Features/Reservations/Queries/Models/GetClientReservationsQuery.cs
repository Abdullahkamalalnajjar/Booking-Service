namespace Project.Core.Features.Reservations.Queries.Models
{
    public class GetClientReservationsQuery : IRequest<Response<IEnumerable<ReservationDto>>>
    {
        public string ClientId { get; set; }

        public GetClientReservationsQuery(string clientId)
        {
            ClientId = clientId;
        }
    }
}
