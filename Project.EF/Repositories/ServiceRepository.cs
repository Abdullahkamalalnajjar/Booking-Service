namespace Project.EF.Repositories
{
    public class ServiceRepository : GenericRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
