using Project.Core.Features.Coupons.Command.Models;

namespace Project.Core.Mapping.CouponService
{
    public partial class CouponProfile : Profile
    {

        public void GenerateCouponMapping()
        {
            CreateMap<GenerateCouponCommand, ServicesCoupon>();
        }
    }
}
