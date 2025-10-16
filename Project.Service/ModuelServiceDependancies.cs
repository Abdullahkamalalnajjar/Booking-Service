using Microsoft.Extensions.DependencyInjection;

namespace Project.Service
{
    public static class ModuelServiceDependancies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IUploadFileService, UploadFileService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IEmailSender, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IClaimService, ClaimService>();
            services.AddTransient<IServiceEntityService, ServiceEntityService>();
            services.AddTransient<IVerificationRequestService, VerificationRequestService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IFavoriteServices, FavoriteServices>();
            services.AddTransient<IStripeService, StripeService>();
            services.AddTransient<ICouponServices, CouponServices>();
            services.AddHttpClient<PaymobService>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(60);
            });
            services.AddScoped<PaymobService>();

            return services;
        }
    }
}
