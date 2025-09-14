namespace Project.EF.Configurations;

public class ServiceReviewConfig : IEntityTypeConfiguration<ServiceReview>
{
    public void Configure(EntityTypeBuilder<ServiceReview> builder)
    {
 
        builder.HasOne(sr => sr.Service)
            .WithMany(s => s.Reviews)
            .HasForeignKey(sr => sr.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}