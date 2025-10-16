namespace Project.Core.Features.Coupons.Command.Models
{
    public class GenerateCouponCommand : IRequest<Response<string>>
    {
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ServiceId { get; set; }

    }

}
