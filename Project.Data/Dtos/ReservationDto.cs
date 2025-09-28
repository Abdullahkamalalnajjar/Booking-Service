namespace Project.Data.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationPeriod { get; set; }
        public int NumberOfGuests { get; set; }
        public string PaymentMethod { get; set; }
        public string? DiscountCoupon { get; set; }
        public int ServiceId { get; set; }
        public ServiceDto Service { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }

    }
    public class ReservationPackageDto
    {
        public int ServicePackageId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public ServicePackageDto ServicePackage { get; set; } = null!;
    }
}
