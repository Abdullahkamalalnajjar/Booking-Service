namespace Project.Data.Entities
{

    public class ReservationPackage
    {
         public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public int ServicePackageId { get; set; }
        public ServicePackage ServicePackage { get; set; } = null!;
    }
}


