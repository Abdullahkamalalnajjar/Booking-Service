using Project.Data.Entities;
using Project.Data.Interfaces;

namespace Project.EF.Repositories
{
    public class ServicePackageRepository : GenericRepository<ServicePackage>, IServicePackageRepository
    {
        public ServicePackageRepository(ApplicationDbContext context) : base(context)
        {
        }
        // Add custom methods for ServicePackage if needed
    }
}