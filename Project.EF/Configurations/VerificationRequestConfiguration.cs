using Project.Data.Entities.verifyRequst;
using Project.Data.Enum;

namespace Project.EF.Configurations
{
    public class VerificationRequestConfiguration : IEntityTypeConfiguration<VerificationRequest>
    {
        public void Configure(EntityTypeBuilder<VerificationRequest> builder)
        {
            builder.Property(s => s.Status).HasConversion(o => o.ToString(), o => (VerificationStatus)Enum.Parse(typeof(VerificationStatus), o));

            builder.HasOne(v => v.Service)
               .WithOne(s => s.VerificationRequest)
               .HasForeignKey<VerificationRequest>(v => v.ServiceId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

