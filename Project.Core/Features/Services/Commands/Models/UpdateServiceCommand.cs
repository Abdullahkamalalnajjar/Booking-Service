
namespace Project.Core.Features.Services.Commands.Models
{
    public class UpdateServiceCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        public decimal? Price { get; set; }
        public string? Policies { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string? Deposit { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public ICollection<UpdateServiceFeatureDto>? Features { get; set; }
        public ICollection<UpdateServicePackageDto>? Packages { get; set; }
    }

    public class UpdateServiceFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
    }

    public class UpdateServicePackageDto
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public List<UpdateServicePackageItemDto>? Items { get; set; }
    }

    public class UpdateServicePackageItemDto
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
    }
}
