using Project.Data.Entities.verifyRequst;
using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

