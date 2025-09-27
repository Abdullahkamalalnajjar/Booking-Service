using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EF.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(s => s.ReservationPeriod).HasConversion(o => o.ToString(), o => (ReservationPeriod)Enum.Parse(typeof(ReservationPeriod), o));
            builder.Property(s => s.PaymentMethod).HasConversion(o => o.ToString(), o => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), o));
        }
    }
}
