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

        private static readonly Expression<Func<Reservation, ReservationDto>> ReservationDto = s => new ReservationDto
        {
            Id = s.Id,
            ReservationDate = s.ReservationDate,
            ReservationPeriod = s.ReservationPeriod.ToString(),
            NumberOfGuests = s.NumberOfGuests,
            PaymentMethod = s.PaymentMethod.ToString(),
            DiscountCoupon = s.DiscountCoupon,
            ServiceId = s.ServiceEntityId,
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
                Packages = s.ServiceEntity.Packages.Select(sp => new ServicePackageDto
                {
                    Id = sp.Id,
                    Title = sp.Title,
                    Price = sp.Price,
                    Items = sp.Items.Select(pi => new ServicePackageItemDto
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