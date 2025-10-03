using Project.Data.Enum;
using System.Linq.Expressions;

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

        public async Task<int> CreateReservationAsync(Reservation reservation, CancellationToken cancellationToken)
        {
            var createReservation = await _unitOfWork.reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return createReservation.Id;
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

        public async Task<ReservationDto?> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _unitOfWork.reservationRepository.GetTableAsTracking()
            .Where(x => x.Id == reservationId)
            .Select(ReservationDto).FirstOrDefaultAsync();
            return reservation;
        }

        public async Task<IEnumerable<ReservationDto>> GetClientReservationsAsync(string clientId)
        {
            var reservationt = await _unitOfWork.reservationRepository.GetTableNoTracking()
                .Where(x => x.ClientId == clientId).Select(ReservationDto).ToListAsync();
            return reservationt;


        }

        public async Task<Reservation> GetById(int reservationId)
        {
            return await _unitOfWork.reservationRepository.GetByIdAsync(reservationId);
        }

        public async Task<bool> PayWithWalletAsync(int reservationId)
        {
            // Get reservation
            var reservation = await _unitOfWork.reservationRepository.GetTableAsTracking().Where(x => x.Id == reservationId).Include(x => x.ServiceEntity).FirstOrDefaultAsync();
            if (reservation == null)
                return false;
            // get client wallet
            var wallet = await _unitOfWork.Wallets.GetTableAsTracking().Where(x => x.UserId.Equals(reservation.ClientId)).FirstOrDefaultAsync();
            if (wallet == null)
                return false;
            // get service price
            if (wallet.Balance >= reservation.ServiceEntity.Deposit)
            {
                wallet.Balance -= (decimal)reservation.ServiceEntity.Deposit;
                reservation.IsPaid = true;
                _unitOfWork.Wallets.Update(wallet);
                _unitOfWork.reservationRepository.Update(reservation);
                // create wallet transaction
                var walletTransaction = new WalletTransaction
                {
                    WalletId = wallet.Id,
                    Amount = (decimal)reservation.ServiceEntity.Deposit,
                    Status = WalletTransactionStatus.Paid,
                    Type = WalletTransactionType.Deposit,
                    CreatedAt = DateTime.UtcNow,
                    PaidAt = DateTime.UtcNow,
                    OrderId = 0, // not applicable here
                    MerchantOrderId = null // not applicable here
                };
                await _unitOfWork.WalletTransactions.AddAsync(walletTransaction, CancellationToken.None);
                await _unitOfWork.CompeleteAsync();
                return true;
            }
            return false;

        }

        private static readonly Expression<Func<Reservation, ReservationDto>> ReservationDto = s => new ReservationDto
        {
            Id = s.Id,
            ReservationDate = s.ReservationDate,
            ReservationPeriod = s.ReservationPeriod.ToString(),
            NumberOfGuests = s.NumberOfGuests,
            PaymentMethod = s.PaymentMethod.ToString(),
            DiscountCoupon = s.DiscountCoupon,
            ServiceId = s.ServiceEntityId,
            IsPaid = s.IsPaid,
            ClientId = s.ClientId,
            ClientName = s.Client.FullName,
            Service = new ServiceDto
            {
                Id = s.ServiceEntity.Id,
                Name = s.ServiceEntity.Name,
                Description = s.ServiceEntity.Description,
                ImageUrl = s.ServiceEntity.ImageUrl,
                Location = s.ServiceEntity.Location,
                Capacity = s.ServiceEntity.Capacity,
                Policies = s.ServiceEntity.Policies,
                Price = s.ServiceEntity.Price,
                ServiceCategoryId = s.ServiceEntity.ServiceCategoryId,
                CategoryName = s.ServiceEntity.Category.Name,
                Deposit = s.ServiceEntity.Deposit,
                Longitude = s.ServiceEntity.Longitude,
                Latitude = s.ServiceEntity.Latitude,
                Features = s.ServiceEntity.Features.Select(sf => new ServiceFeatureDto
                {
                    Id = sf.Id,
                    Name = sf.Name,
                    Icon = sf.Icon
                }).ToList(),
                Images = s.ServiceEntity.Images.Select(si => new ServiceImageDto
                {
                    Id = si.Id,
                    Url = si.ImageUrl
                }).ToList(),
                Packages = s.ReservationPackages.Select(sp => new ServicePackageDto
                {
                    Id = sp.ServicePackageId,
                    Title = sp.ServicePackage.Title,
                    Price = sp.ServicePackage.Price,
                    Items = sp.ServicePackage.Items.Select(pi => new ServicePackageItemDto
                    {
                        Id = pi.Id,
                        Name = pi.Name,
                        ServicePackageId = pi.ServicePackageId
                    }).ToList()
                }).ToList(),

            }
        };

    }
}