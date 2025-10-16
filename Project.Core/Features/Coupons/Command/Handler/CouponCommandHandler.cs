using Project.Core.Features.Coupons.Command.Models;

namespace Project.Core.Features.Coupons.Command.Handler
{
    public class CouponCommandHandler(ICouponServices couponService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GenerateCouponCommand, Response<string>>
    {
        private readonly ICouponServices _couponService = couponService;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<string>> Handle(GenerateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<ServicesCoupon>(request);
            coupon.Code = GenerateRandomCode();
            var code = await _couponService.GenerateCouponAsync(coupon, cancellationToken);
            return Success<string>(code);
        }
        #region GenerateRandomCode
        public static string GenerateRandomCode(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
    }
}
