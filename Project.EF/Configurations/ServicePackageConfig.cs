namespace Project.EF.Configurations;

public class ServicePackageConfig : IEntityTypeConfiguration<ServicePackage>
{
    public void Configure(EntityTypeBuilder<ServicePackage> builder)
    {
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Title).IsRequired();
        builder.Property(sp => sp.Price).HasColumnType("decimal(18,2)");


        builder.HasOne(sp => sp.Service)
            .WithMany(s => s.Packages)
            .HasForeignKey(sp => sp.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}