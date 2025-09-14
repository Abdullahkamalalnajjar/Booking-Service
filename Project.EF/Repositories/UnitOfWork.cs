namespace Project.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; private set; }
        public IServiceRepository Services { get; private set; }
        public IServiceImageRepository ServiceImages { get; private set; }
        public IServiceFeatureRepository ServiceFeatures { get; private set; }
        public IServicePackageRepository ServicePackages { get; private set; }
        public IServiceReviewRepository ServiceReviews { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Services = new ServiceRepository(_context);
            ServiceImages = new ServiceImageRepository(_context);
            ServiceFeatures = new ServiceFeatureRepository(_context);
            ServicePackages = new ServicePackageRepository(_context);
            ServiceReviews = new ServiceReviewRepository(_context);
        }

        public async Task<int> CompeleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
