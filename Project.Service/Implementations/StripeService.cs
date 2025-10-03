
using Microsoft.Extensions.Logging;
using Stripe.Checkout;

namespace Project.Service.Implementations
{
    public class StripeService(IOptions<StripeSettings> setting, ILogger<StripeService> logger, IUnitOfWork unitOfWork) : IStripeService
    {
        private readonly StripeSettings setting = setting.Value;
        private readonly ILogger<StripeService> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Account> CreateConnectAccountAsync(string email)
        {
            StripeConfiguration.ApiKey = setting.SecretKey;
            var options = new AccountCreateOptions
            {
                Type = "express",
                Email = email,
                Country = "US",
                Capabilities = new AccountCapabilitiesOptions
                {
                    CardPayments = new AccountCapabilitiesCardPaymentsOptions { Requested = true },
                    Transfers = new AccountCapabilitiesTransfersOptions { Requested = true }
                }
            };

            var service = new AccountService();
            return await service.CreateAsync(options);
        }
        public async Task<string> GenerateAccountLinkAsync(string accountId, string returnUrl, string refreshUrl)
        {
            var options = new AccountLinkCreateOptions
            {
                Account = accountId,
                RefreshUrl = refreshUrl,
                ReturnUrl = returnUrl,
                Type = "account_onboarding"
            };

            var service = new AccountLinkService();
            var accountLink = await service.CreateAsync(options);

            return accountLink.Url;
        }

        #region
        public async Task<string> CreateCheckoutSessionAsync(int requestId, string OwnerName, decimal? price, string stripeAccountId)
        {
            StripeConfiguration.ApiKey = setting.SecretKey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions {
             PriceData = new SessionLineItemPriceDataOptions
            {
                Currency = "usd",
                UnitAmount = (long)(price * 100), // السعر بالـ cents
                ProductData = new SessionLineItemPriceDataProductDataOptions
                {
                    Name = $"Payment for Service - {OwnerName}"
                }
            },

                Quantity = 1
            }
        },
                Mode = "payment",
                SuccessUrl = "http://bookingservice.runasp.net/payment-success.html?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://bookingservice.runasp.net/payment-cancel",
                PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    TransferData = new SessionPaymentIntentDataTransferDataOptions
                    {
                        Destination = stripeAccountId
                    }
                }
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            // 📝 حفظ بيانات الدفع في الطلب
            var request = await _unitOfWork.reservationRepository.GetTableAsTracking().Where(x => x.Id == requestId).FirstOrDefaultAsync();
            if (request != null)
            {
                request.CheckoutSessionId = session.Id; // cs_...
                request.PaymentIntentId = session.PaymentIntentId; // pi_...
                await _unitOfWork.CompeleteAsync();
            }

            return session.Url; // رابط الدفع الجاهز من Stripe
        }
        #endregion
        public async Task HandleWebhookAsync(string json, string stripeSignature, string webhookSecret)
        {
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    stripeSignature,
                    webhookSecret
                );

                switch (stripeEvent.Type)
                {
                    case "checkout.session.completed": // ✅ كده الاسم الرسمي من Stripe
                        var session = stripeEvent.Data.Object as Session;
                        if (session != null)
                        {
                            var request = await _unitOfWork.reservationRepository
                                .GetTableAsTracking()
                                .Where(x => x.CheckoutSessionId == session.Id)
                                .FirstOrDefaultAsync();

                            if (request != null)
                            {
                                request.IsPaid = true;
                                request.PaymentIntentId = session.PaymentIntentId;
                                await _unitOfWork.CompeleteAsync();
                            }
                        }
                        break;

                    case "payment_intent.succeeded": // ✅ الاسم الصح للـ intent
                        var intent = stripeEvent.Data.Object as PaymentIntent;
                        if (intent != null)
                        {
                            var request = await _unitOfWork.reservationRepository
                                .GetTableAsTracking()
                                .Where(x => x.PaymentIntentId == intent.Id)
                                .FirstOrDefaultAsync();

                            if (request != null)
                            {
                                request.IsPaid = true;
                                await _unitOfWork.CompeleteAsync();
                            }
                        }
                        break;

                    default:
                        _logger.LogInformation("Unhandled Stripe event: {EventType}", stripeEvent.Type);
                        break;
                }
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe webhook error");
                throw;
            }
        }


    }
}
