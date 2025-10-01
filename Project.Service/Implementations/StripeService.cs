
namespace Project.Service.Implementations
{
    public class StripeService(IOptions<StripeSettings> setting) : IStripeService
    {
        private readonly StripeSettings setting = setting.Value;

        public async Task<Account> CreateConnectAccountAsync(string email)
        {
            StripeConfiguration.ApiKey = setting.SecretKey;
            var options = new AccountCreateOptions
            {
                Type = "express", // أو standard حسب البزنس موديل
                Email = email,
                Country = "EG", // الدولة، ممكن تخليها dynamic  
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

    }
}
