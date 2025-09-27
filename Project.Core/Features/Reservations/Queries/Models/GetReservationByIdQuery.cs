using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Reservations.Queries.Models
{
    public class GetReservationByIdQuery : IRequest<Response<ReservationDto>>
    {
        public int Id { get; set; }
    }
}
