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
        IVerificationRequestRepository verificationRequestRepository { get; }
        IReservationRepository reservationRepository { get; }
        IReservationPackageRespository ReservationPackages { get; }
        IWalletTransactionRepository WalletTransactions { get; }
        IWalletRepository Wallets { get; }
        IFavoriteRespository favoritesService { get; }
        ICouponRepository Coupons { get; }
        Task<int> CompeleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
