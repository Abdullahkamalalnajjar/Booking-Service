using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Services.Commands.Models
{
    public class CreateServiceCommand:IRequest<Response<string>>
    {
        public string Name { get; set; } = null!;
        public IFormFile? Image { get; set; } // صورة رئيسية
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string? Policies { get; set; }
        public int ServiceCategoryId { get; set; }

        public string UserId { get; set; } = null!;

        // صور إضافية
        public List<IFormFile>? Images { get; set; }

        // الخدمات الأساسية
        public List<string>? Features { get; set; }

        // الباقات
        public List<ServicePackageDto>? Packages { get; set; }
    }

    public class ServicePackageDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string> Items { get; set; } = new();
    }
}
