namespace Project.Service.Abstracts
{
    public interface IReservationService
    {
        Task<int> CreateReservationAsync(Reservation reservation, CancellationToken cancellationToken);
        Task<bool> UpdateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(Reservation reservation);
        Task<bool> CancelReservationAsync(int reservationId);
        Task<IEnumerable<ReservationDto>> GetClientReservationsAsync(string clientId);
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto> GetReservationByIdAsync(int reservationId);
        Task<Reservation> GetById(int reservationId);

    }
}
