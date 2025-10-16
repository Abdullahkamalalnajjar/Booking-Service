using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Coupons.Command.Models;
using Project.Core.Features.Coupons.Queries.Models;
using Project.Data.AppMetaData;

namespace Project.Api.Controllers
{

    public class CouponController : AppBaseController
    {
        [HttpPost(Router.CouponRouting.Generate)]
        public async Task<IActionResult> Generate([FromBody] GenerateCouponCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpGet(Router.CouponRouting.List)]
        public async Task<IActionResult> GetAllCoupons()
        {
            var result = await Mediator.Send(new GetCouponsQueries());
            return NewResult(result);
        }
    }
}
