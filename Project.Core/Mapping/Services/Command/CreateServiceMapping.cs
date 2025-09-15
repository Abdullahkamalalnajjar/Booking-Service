using Project.Core.Features.Services.Commands.Models;

namespace Project.Core.Mapping.Services
{
    public partial class ServiceProfile
    {
        public void CreateServiceMapping()
        {
            CreateMap<CreateServiceCommand, ServiceEntity>();
            CreateMap<CreateServiceFeatureDto, ServiceFeature>();
            CreateMap<CreateServicePackageItemDto, ServicePackageItem>();
            CreateMap<CreateServicePackageDto, ServicePackage>();
        }
    }
}
