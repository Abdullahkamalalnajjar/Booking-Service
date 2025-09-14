namespace Project.EF.Configurations;

public class ServiceImageConfig : IEntityTypeConfiguration<ServiceImage>
{
    public void Configure(EntityTypeBuilder<ServiceImage> builder)
    {

        builder.HasOne(si => si.Service)
            .WithMany(s => s.Images)
            .HasForeignKey(si => si.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}