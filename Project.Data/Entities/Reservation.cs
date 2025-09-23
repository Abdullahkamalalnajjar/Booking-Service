using Project.Data.Enum;
using System;
using System.Collections.Generic;

namespace Project.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationPeriod ReservationPeriod { get; set; } 
        public int NumberOfGuests { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? DiscountCoupon { get; set; }
        public int ServiceEntityId { get; set; }
        public ServiceEntity ServiceEntity { get; set; }
        public ICollection<ServicePackage> Packages { get; set; } = new List<ServicePackage>();
    }

  
}
