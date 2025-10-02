using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Project.Api.Base;
using Project.Data.AppMetaData;
using Project.Data.Helpers;
using Project.Service.Abstracts;

namespace Project.Api.Controllers
{

    public class StripeController(IOptions<StripeSettings> options, IStripeService stripeService) : AppBaseController
    {
        private readonly StripeSettings _options = options.Value;
        private readonly IStripeService _stripeService = stripeService;

        [HttpPost(Router.StripeRouting.Webhook)]
        public async Task<IActionResult> HandleWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeSignature = Request.Headers["Stripe-Signature"];
            var webhookSecret = _options.WebhookSecret;

            await _stripeService.HandleWebhookAsync(json, stripeSignature, webhookSecret);
            return Ok();
        }
    }
}
