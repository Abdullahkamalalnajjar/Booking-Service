namespace Project.Service.Abstracts
{
    public interface ICouponServices
    {
        public Task<string> GenerateCouponAsync(ServicesCoupon coupon, CancellationToken cancellationToken);
        public Task<bool> ValidateCouponAsync(string code, int serviceId);
        public Task<CouponDto?> GetCouponByCodeAsync(string code, int serviceId);
        public Task<IEnumerable<CouponDto>> GetCouponsByServiceIdAsync(int serviceId);
        public Task<IEnumerable<CouponDto>> GetAllCouponsForServiceAsync(int serviceId);
        public Task<bool> DeleteCouponAsync(int id, int serviceId);
        public Task<IEnumerable<CouponDto>> GetAllCouponsAsync();
    }
}
