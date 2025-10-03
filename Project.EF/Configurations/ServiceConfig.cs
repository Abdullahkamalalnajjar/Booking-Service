namespace Project.EF.Configurations;
public class ServiceConfig : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Price).HasColumnType("decimal(18,2)");
        builder.Property(s => s.Deposit).HasColumnType("decimal(18,2)");
        builder.HasOne(s => s.Category).WithMany()
       .HasForeignKey(s => s.ServiceCategoryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.VerificationRequest);
    }
}