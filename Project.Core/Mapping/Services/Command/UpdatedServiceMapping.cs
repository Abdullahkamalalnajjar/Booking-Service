using Project.Core.Features.Services.Commands.Models;

namespace Project.Core.Mapping.Services
{
    public partial class ServiceProfile
    {
        public void UpdatedServiceMapping()
        {
            CreateMap<UpdateServiceCommand, ServiceEntity>();
            CreateMap<UpdateServiceFeatureDto, ServiceFeature>();
            CreateMap<UpdateServicePackageItemDto, ServicePackageItem>();
            CreateMap<UpdateServicePackageDto, ServicePackage>();
        }
    }
}