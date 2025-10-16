namespace Project.Data.Dtos
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
