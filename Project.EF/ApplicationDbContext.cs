using Project.Data.Entities.chat;
using Project.Data.Entities.verifyRequst;


namespace Project.EF
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add your custom model configurations here  
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }



        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }
        public DbSet<ServiceFeature> ServiceFeatures { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        public DbSet<ServicePackageItem> ServicePackageItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<VerificationRequest> VerificationRequests { get; set; }
        public DbSet<ServicesCoupon> Coupons { get; set; }


    }
}
