namespace Project.Service.Abstracts
{
    public interface IStripeService
    {
        public Task<Account> CreateConnectAccountAsync(string email);
        public Task<string> GenerateAccountLinkAsync(string accountId, string returnUrl, string refreshUrl);
        public Task<string> CreateCheckoutSessionAsync(int requestId, string OwnerName, decimal price, string stripeAccountId);
        public Task HandleWebhookAsync(string json, string stripeSignature, string webhookSecret);

    }
}
