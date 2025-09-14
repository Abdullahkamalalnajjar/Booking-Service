namespace Project.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IServiceRepository Services { get; }
        IServiceImageRepository ServiceImages { get; }
        IServiceFeatureRepository ServiceFeatures { get; }
        IServicePackageRepository ServicePackages { get; }
        IServiceReviewRepository ServiceReviews { get; }

        Task<int> CompeleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
