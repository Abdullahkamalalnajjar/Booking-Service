﻿using static Project.Data.Dtos.PaymobDto;

namespace Project.Service.Abstracts
{

    public interface IPaymobService
    {
        Task<string> AuthenticateAsync();

        Task<long> CreateOrderAsync(string authToken, int amountCents, string currency, string merchantOrderId);

        Task<string> CreatePaymentKeyAsync(
            string authToken, long orderId, int amountCents, string currency,
            PaymobBillingData billing, string integrationId);

        Task<CardInitResponse> InitCardPaymentAsync(CreateCardPaymentRequest input);

        Task<WalletInitResponse> InitWalletPaymentAsync(CreateWalletPaymentRequest input);

        bool VerifyHmac(IDictionary<string, string?> received, string providedHmac, string[] fieldOrder);
    }

}
