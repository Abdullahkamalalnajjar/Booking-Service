using Project.Core.Features.Reservations.Command.Models;

namespace Project.Core.Features.Reservations.Command.Handler
{
    public class ReservationtCommandHandler(IReservationService reservationService, IUnitOfWork unitOfWork, IMapper mapper) : ResponseHandler,
        IRequestHandler<CreateReservationCommand, Response<string>>,
        IRequestHandler<UpdateReservationCommand, Response<string>>,
        IRequestHandler<DeleteReservationCommand, Response<string>>
    {
        private readonly IReservationService _reservationService = reservationService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        #region CreateReservation
        public async Task<Response<string>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            #region  Check if the service package exists  
            var allowServicePackageIds = await _unitOfWork.ServicePackages.GetTableNoTracking().Where(x => x.ServiceId == request.ServiceEntityId).Select(x => x.Id).ToListAsync();
            if (request.Packages.Except(allowServicePackageIds).ToList().Any())
                return NotFound<string>("One or more service packages do not exist");
            #endregion      
            var reservationMapping = _mapper.Map<Reservation>(request);
            var reservation = await _reservationService.CreateReservationAsync(reservationMapping, cancellationToken);
            if (reservation == true) return Success<string>("Create Successfly");
            return NotFound<string>("Faild to Create");
        }
        #endregion

        #region DeleteReservation
        public async Task<Response<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetById(request.Id);
            var result = await _reservationService.DeleteReservationAsync(reservation);
            if (result) return Success<string>("Deleted Successfly");
            return NotFound<string>("Faild to Delete");
        }
        #endregion

        #region UpdateReservation
        public async Task<Response<string>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var oldReservation = await _reservationService.GetById(request.Id);
            if (oldReservation == null)
                return NotFound<string>("Reservation not found");

            try
            {
                // ✅ تحديث البيانات الأساسية
                if (request.ReservationDate != default)
                    oldReservation.ReservationDate = request.ReservationDate;

                if (request.ReservationPeriod != default)
                    oldReservation.ReservationPeriod = request.ReservationPeriod;

                if (request.NumberOfGuests > 0)
                    oldReservation.NumberOfGuests = request.NumberOfGuests;

                if (request.PaymentMethod != default)
                    oldReservation.PaymentMethod = request.PaymentMethod;

                if (!string.IsNullOrEmpty(request.DiscountCoupon))
                    oldReservation.DiscountCoupon = request.DiscountCoupon;

                if (request.ServiceEntityId > 0)
                    oldReservation.ServiceEntityId = request.ServiceEntityId;

                if (!string.IsNullOrEmpty(request.ClientId))
                    oldReservation.ClientId = request.ClientId;

                // ✅ التحقق من الباكجات المسموح بها
                var allowServicePackageIds = await _unitOfWork.ServicePackages
                    .GetTableNoTracking()
                    .Select(x => x.Id)
                    .ToListAsync();

                var notFoundPackages = request.Packages.Except(allowServicePackageIds).ToList();
                if (notFoundPackages.Any())
                {
                    return NotFound<string>($"Invalid package IDs: {string.Join(", ", notFoundPackages)}");
                }

                // ✅ تحديث جدول ReservationPackages (clear + add)
                var oldPackages = _unitOfWork.ReservationPackages
                    .GetTableNoTracking()
                    .Where(x => x.ReservationId == oldReservation.Id);

                _unitOfWork.ReservationPackages.DeleteRange(oldPackages);

                var newPackages = request.Packages.Select(p => new ReservationPackage
                {
                    ReservationId = oldReservation.Id,
                    ServicePackageId = p
                }).ToList();

                await _unitOfWork.ReservationPackages.AddRangeAsync(newPackages);

                // ✅ تحديث وقت آخر تعديل
                oldReservation.UpdatedAt = DateTime.UtcNow;

                var result = await _reservationService.UpdateAsync(oldReservation, cancellationToken);

                return result == "Updated"
                    ? Success("Reservation updated successfully.")
                    : BadRequest<string>("Failed to update reservation.");
            }
            catch (Exception ex)
            {
                return BadRequest<string>($"Error while updating: {ex.Message}");
            }
        }
        #endregion




    }
}
