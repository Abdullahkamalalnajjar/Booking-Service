namespace Project.Data.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string ImageUrl { get; set; } 
        public string Description { get; set; }
        public string Location { get; set; } 
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string Policies { get; set; } 
        public int ServiceCategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal? Deposit { get; set; } 
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public List<ServiceImageDto> Images { get; set; } = new List<ServiceImageDto>();
        public List<ServiceFeatureDto> Features { get; set; } = new List<ServiceFeatureDto>();
        public List<ServicePackageDto> Packages { get; set; } = new List<ServicePackageDto>();
        public List<ServiceReviewDto> Reviews { get; set; } = new List<ServiceReviewDto>();
    }
    public class ServiceImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
    public class ServiceFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Icon { get; set; }
    }
    public class ServicePackageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public List<ServicePackageItemDto> Items { get; set; }
    }
    public class ServiceReviewDto
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
    public class ServicePackageItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ServicePackageId { get; set; }
    }
}
