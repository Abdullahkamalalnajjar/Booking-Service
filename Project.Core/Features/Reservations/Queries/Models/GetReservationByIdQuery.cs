namespace Project.Core.Features.Reservations.Queries.Models
{
    public class GetReservationByIdQuery : IRequest<Response<ReservationDto>>
    {
        public int Id { get; set; }

        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
