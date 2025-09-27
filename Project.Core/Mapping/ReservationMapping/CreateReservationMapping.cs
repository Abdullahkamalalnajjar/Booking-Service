using Project.Core.Features.Reservations.Command.Models;
using Project.Core.Features.VerificationRequests.Commands.Models;
using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Mapping.ReservationMapping
{
    public partial class ReservationProfile
    {
        public void CreateReservationMapping()
        {
            CreateMap<CreateReservationCommand, Reservation>();
        }
    }
}
