namespace Project.Data.Entities
{
    public class ServicesCoupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive => ExpiryDate >= DateTime.UtcNow;
        public int ServiceId { get; set; }
        public ServiceEntity Service { get; set; }
    }
}
