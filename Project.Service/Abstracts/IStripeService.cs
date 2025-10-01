namespace Project.Service.Abstracts
{
    public interface IStripeService
    {
        public Task<Account> CreateConnectAccountAsync(string email);
        public Task<string> GenerateAccountLinkAsync(string accountId, string returnUrl, string refreshUrl);

    }
}
