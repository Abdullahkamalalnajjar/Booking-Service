
namespace Project.EF
{
    public static class ModuelEFDependancies
    {
        public static IServiceCollection AddEFDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVerificationRequestRepository,VerificationRequestRepository>();


            return services;
        }
    }
}
