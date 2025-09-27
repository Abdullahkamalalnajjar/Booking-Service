using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationPeriod { get; set; }
        public int NumberOfGuests { get; set; }
        public string PaymentMethod { get; set; }
        public string? DiscountCoupon { get; set; }
        public int ServiceEntityId { get; set; }
        public string ClientId { get; set; }
    }
}
