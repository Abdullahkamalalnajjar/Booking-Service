using Project.Core.Features.Services.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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