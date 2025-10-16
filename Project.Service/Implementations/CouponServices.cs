using System.Linq.Expressions;

namespace Project.Service.Implementations
{
    public class CouponServices(IUnitOfWork unitOfWork) : ICouponServices
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task<bool> DeleteCouponAsync(int id, int serviceId)
        {
            var coupon = await _unitOfWork.Coupons.GetTableNoTracking().Where(c => c.Id == id && c.ServiceId == serviceId).FirstOrDefaultAsync();
            if (coupon == null)
            {
                return false; // Coupon not found
            }
            await _unitOfWork.Coupons.Delete(coupon);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<string> GenerateCouponAsync(ServicesCoupon coupon, CancellationToken cancellationToken)
        {
            await _unitOfWork.Coupons.AddAsync(coupon, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return coupon.Code;
        }
        public async Task<IEnumerable<CouponDto>> GetAllCouponsForServiceAsync(int serviceId)
        {
            return await _unitOfWork.Coupons.GetTableNoTracking().Where(c => c.ServiceId == serviceId).Select(CouponDto).ToListAsync();
        }

        public Task<CouponDto?> GetCouponByCodeAsync(string code, int serviceId)
        {
            return _unitOfWork.Coupons.GetTableNoTracking()
                .Where(c => c.Code == code && c.ServiceId == serviceId)
                .Select(CouponDto)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CouponDto>> GetCouponsByServiceIdAsync(int serviceId)
        {
            return await _unitOfWork.Coupons.GetTableNoTracking()
                .Where(c => c.ServiceId == serviceId)
                .Select(CouponDto)
                .ToListAsync();
        }

        public Task<bool> ValidateCouponAsync(string code, int serviceId)
        {
            return _unitOfWork.Coupons.GetTableNoTracking()
                .AnyAsync(c => c.Code == code && c.ServiceId == serviceId && c.IsActive);
        }

        public async Task<IEnumerable<CouponDto>> GetAllCouponsAsync()
        {
            return await _unitOfWork.Coupons.GetTableNoTracking().Select(CouponDto).ToListAsync();
        }
        #region Expressions to DTOs
        private static readonly Expression<Func<ServicesCoupon, CouponDto>> CouponDto = s => new CouponDto
        {
            Id = s.Id,
            Code = s.Code,
            Discount = s.Discount,
            ExpiryDate = s.ExpiryDate,
            IsActive = s.IsActive,
            ServiceId = s.ServiceId,
            ServiceName = s.Service.Name
        };
        #endregion
    }
}
