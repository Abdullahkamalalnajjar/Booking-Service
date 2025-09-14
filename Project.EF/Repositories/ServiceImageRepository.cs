using Project.Data.Entities;
using Project.Data.Interfaces;

namespace Project.EF.Repositories
{
    public class ServiceImageRepository : GenericRepository<ServiceImage>, IServiceImageRepository
    {
        public ServiceImageRepository(ApplicationDbContext context) : base(context)
        {
        }
        // Add custom methods for ServiceImage if needed
    }
}