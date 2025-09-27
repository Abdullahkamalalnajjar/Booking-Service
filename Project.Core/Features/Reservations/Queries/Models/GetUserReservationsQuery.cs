using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Reservations.Queries.Models
{
    public class GetUserReservationsQuery : IRequest<Response<ReservationDto>>
    {
        public int ClientId { get; set; }
    }
}
