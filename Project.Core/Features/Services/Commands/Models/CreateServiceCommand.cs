namespace Project.Core.Features.Services.Commands.Models
{
    public class CreateServiceCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string? Policies { get; set; }
        public int ServiceCategoryId { get; set; }
        public string UserId { get; set; } = null!;
        public string? Deposit { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public List<CreateServiceFeatureDto>? Features { get; set; }
        public List<CreateServicePackageDto>? Packages { get; set; }
    }

    public class CreateServicePackageDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }


        public List<CreateServicePackageItemDto> Items { get; set; }
    }
    public class CreateServicePackageItemDto
    {
        public string Name { get; set; } = null!;
    }
    public class CreateServiceFeatureDto
    {
        public string Name { get; set; }
        public string? Icon { get; set; }

    }

}
