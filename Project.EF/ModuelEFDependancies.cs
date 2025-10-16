
namespace Project.EF
{
    public static class ModuelEFDependancies
    {
        public static IServiceCollection AddEFDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVerificationRequestRepository, VerificationRequestRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationPackageRespository, ReservationPackageRespository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IWalletTransactionRepository, WalletTransactionRepository>();
            services.AddTransient<IFavoriteRespository, FavoriteRespository>();
            services.AddTransient<ICouponRepository, CouponRepository>();
            return services;
        }
    }
}
