using Project.Data.Enum;

namespace Project.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationPeriod ReservationPeriod { get; set; }
        public int NumberOfGuests { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? DiscountCoupon { get; set; }
        public int ServiceEntityId { get; set; }
        public ServiceEntity ServiceEntity { get; set; }
        public string ClientId { get; set; } = null!;
        public ApplicationUser Client { get; set; } = null!;
        public ICollection<ReservationPackage> ReservationPackages { get; set; } = new List<ReservationPackage>();

    }


}
