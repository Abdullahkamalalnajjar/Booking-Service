namespace Project.EF.Configurations
{
    public class ReservationPackageConfiguration : IEntityTypeConfiguration<ReservationPackage>
    {
        public void Configure(EntityTypeBuilder<ReservationPackage> builder)
        {
            builder.HasKey(rp => new { rp.ReservationId, rp.ServicePackageId });

            builder.HasOne(rp => rp.Reservation)
                   .WithMany(r => r.ReservationPackages)
                   .HasForeignKey(rp => rp.ReservationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.ServicePackage)
                   .WithMany(sp => sp.ReservationPackages)
                   .HasForeignKey(rp => rp.ServicePackageId)
                   .OnDelete(DeleteBehavior.NoAction); // 👈 نمنع الكاسكيد من هنا
        }
    }
}
