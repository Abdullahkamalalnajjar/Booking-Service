
using Project.Data.Enum;

namespace Project.EF.Configurations
{
    public class WalletTransactionConfiguration : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(s => s.Status).HasConversion(o => o.ToString(), o => (WalletTransactionStatus)Enum.Parse(typeof(WalletTransactionStatus), o));
            builder.Property(s => s.Type).HasConversion(o => o.ToString(), o => (WalletTransactionType)Enum.Parse(typeof(WalletTransactionType), o));

        }
    }
}
