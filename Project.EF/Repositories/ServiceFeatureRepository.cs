using Project.Data.Entities;
using Project.Data.Interfaces;

namespace Project.EF.Repositories
{
    public class ServiceFeatureRepository : GenericRepository<ServiceFeature>, IServiceFeatureRepository
    {
        public ServiceFeatureRepository(ApplicationDbContext context) : base(context)
        {
        }
        // Add custom methods for ServiceFeature if needed
    }
}