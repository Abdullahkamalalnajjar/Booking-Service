using Project.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Reservations.Command.Models
{
    public class DeleteReservationCommand : IRequest<Response<string>>
    {
        public int Id { get; set; } 
    }
   
}
