using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Abstracts
{
    public interface IReservationService
    {
        Task<bool> CreateReservationAsync( Reservation reservation, CancellationToken cancellationToken);
        Task<bool> UpdateReservationAsync( Reservation reservation);
        Task<bool> DeleteReservationAsync( Reservation reservation);
        Task<bool> CancelReservationAsync(int reservationId);
        Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(string clientId);
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto> GetReservationByIdAsync(int reservationId);
    }
}
