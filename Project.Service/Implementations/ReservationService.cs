using Project.Data.Entities;
using Project.Data.Entities.verifyRequst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Service.Implementations
{
    public class ReservationService(IUnitOfWork unitOfWork) : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var reservation = await _unitOfWork.reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
             return false;
            _unitOfWork.reservationRepository.Update(reservation);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<bool> CreateReservationAsync(Reservation reservation, CancellationToken cancellationToken)
        {
            await _unitOfWork.reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            _unitOfWork.reservationRepository.Update(reservation);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<bool> DeleteReservationAsync(Reservation reservation)
        {
            _unitOfWork.reservationRepository.Delete(reservation);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservationsAsync()
        {
            return await _unitOfWork.reservationRepository.GetTableNoTracking().Select(ReservationDto).ToListAsync();
        }

        public async Task<ReservationDto> GetReservationByIdAsync(int reservationId)
        {
            var Reservation = await _unitOfWork.reservationRepository.GetTableAsTracking()
            .Where(x => x.Id == reservationId).Select(ReservationDto).FirstOrDefaultAsync();
            return Reservation;
        }

        public async Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(string clientId)
        {
            var reservationt= await _unitOfWork.reservationRepository.GetTableNoTracking()
                .Where(x => x.ClientId == clientId).Select(ReservationDto).ToListAsync();
            return reservationt;


        }

        private static readonly Expression<Func<Reservation, ReservationDto>> ReservationDto = s => new ReservationDto
        {
            Id = s.Id,
            ReservationDate = s.ReservationDate,
            ReservationPeriod = s.ReservationPeriod.ToString(),
            NumberOfGuests = s.NumberOfGuests,
            PaymentMethod = s.PaymentMethod.ToString(),
            DiscountCoupon = s.DiscountCoupon,
            ServiceEntityId = s.ServiceEntityId,
            ClientId = s.ClientId,


        };
        }

}