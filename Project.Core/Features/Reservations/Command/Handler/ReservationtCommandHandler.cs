using Project.Core.Features.Reservations.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Reservations.Command.Handler
{
    public class ReservationtCommandHandler(IReservationService  reservationService, IMapper mapper) : ResponseHandler,
        IRequestHandler<CreateReservationCommand, Response<string>>,
        IRequestHandler<UpdateReservationCommand, Response<string>>,
        IRequestHandler<DeleteReservationCommand, Response<string>>
    {
        private readonly IReservationService _reservationService = reservationService;
        private readonly IMapper _mapper = mapper;
        #region CreateReservation
        public async Task<Response<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationMapping = _mapper.Map<Reservation>(request);
            var reservation = await _reservationService.CreateReservationAsync(reservationMapping, cancellationToken);
            if(reservation == true)return Success <string>("Create Successfly");
            return NotFound<string>("Faild to Create");
        }
        #endregion

        public Task<Response<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

      

    
    }
}
