namespace Project.EF.Repositories
{
    public class ServiceReviewRepository : GenericRepository<ServiceReview>, IServiceReviewRepository
    {
        public ServiceReviewRepository(ApplicationDbContext context) : base(context)
        {
        }
        // Add custom methods for ServiceReview if needed
    }
}