namespace Project.EF.Repositories
{
    public class ReservationPackageRespository : GenericRepository<ReservationPackage>, IReservationPackageRespository
    {
        public ReservationPackageRespository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
