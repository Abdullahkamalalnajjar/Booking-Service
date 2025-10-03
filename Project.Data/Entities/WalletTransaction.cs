using Project.Data.Enum;

namespace Project.Data.Entities;

public class WalletTransaction
{
    public int Id { get; set; }
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public decimal Amount { get; set; }
    public WalletTransactionStatus Status { get; set; } = WalletTransactionStatus.Pending;
    public WalletTransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAt { get; set; }
    public long OrderId { get; set; }
    public string? MerchantOrderId { get; set; }

}
