using Project.Core.Features.Reservations.Command.Models;

namespace Project.Core.Mapping.ReservationMapping
{
    public partial class ReservationProfile
    {
        public void CreateReservationMapping()
        {
            CreateMap<CreateReservationCommand, Reservation>()
                         .ForMember(dest => dest.ReservationPackages,
                         opt => opt.MapFrom(src => src.Packages.Select(id => new ReservationPackage { ServicePackageId = id }).ToList()));
        }
    }
}
