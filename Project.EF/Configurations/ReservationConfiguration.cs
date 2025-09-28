using Project.Data.Enum;

namespace Project.EF.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(s => s.ReservationPeriod).HasConversion(o => o.ToString(), o => (ReservationPeriod)Enum.Parse(typeof(ReservationPeriod), o));
            builder.Property(s => s.PaymentMethod).HasConversion(o => o.ToString(), o => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), o));
         
            builder.HasOne(s => s.Client)
                   .WithMany() 
                   .HasForeignKey(s => s.ClientId)
                   .OnDelete(DeleteBehavior.Restrict); // منع الـ Cascade

        }
    }
}
