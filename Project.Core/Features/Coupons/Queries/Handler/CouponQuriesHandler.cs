using Project.Core.Features.Coupons.Queries.Models;

namespace Project.Core.Features.Coupons.Queries.Handler
{
    public class CouponQuriesHandler(ICouponServices couponService) : ResponseHandler,
        IRequestHandler<GetCouponsQueries, Response<IEnumerable<CouponDto>>>
    {
        private readonly ICouponServices _couponService = couponService;

        public async Task<Response<IEnumerable<CouponDto>>> Handle(GetCouponsQueries request, CancellationToken cancellationToken)
        {
            var coupons = await _couponService.GetAllCouponsAsync();
            return Success(coupons);

        }
    }
}
