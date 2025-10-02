using Project.Data.Enum;

namespace Project.Core.Features.Reservations.Command.Models
{
    public class CreateReservationCommand : IRequest<Response<object>>
    {
        public DateTime ReservationDate { get; set; }
        public ReservationPeriod ReservationPeriod { get; set; }
        public int NumberOfGuests { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public string? DiscountCoupon { get; set; }
        public int ServiceEntityId { get; set; }
        public string ClientId { get; set; } = null!;
        public List<int> Packages { get; set; }

    }
}

