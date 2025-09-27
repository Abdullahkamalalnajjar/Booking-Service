namespace Project.EF.Configurations;

public class ServiceFeatureConfig : IEntityTypeConfiguration<ServiceFeature>
{
    public void Configure(EntityTypeBuilder<ServiceFeature> builder)
    {
    

        builder.HasOne(sf => sf.Service)
            .WithMany(s => s.Features)
            .HasForeignKey(sf => sf.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}