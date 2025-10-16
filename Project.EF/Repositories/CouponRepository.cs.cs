namespace Project.EF.Repositories
{
    public class CouponRepository : GenericRepository<ServicesCoupon>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
