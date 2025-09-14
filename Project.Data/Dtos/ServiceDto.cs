namespace Project.Data.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string Policies { get; set; } = null!;
        public int ServiceCategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ServiceImageDto> Images { get; set; } = new List<ServiceImageDto>();
        public List<ServiceFeatureDto> Features { get; set; } = new List<ServiceFeatureDto>();
        public List<ServicePackageDto> Packages { get; set; } = new List<ServicePackageDto>();
        public List<ServiceReviewDto> Reviews { get; set; } = new List<ServiceReviewDto>();
    }
    public class ServiceImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
    }
    public class ServiceFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Icon { get; set; }
    }
    public class ServicePackageDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string> Items { get; set; } = new List<string>();
    }
    public class ServiceReviewDto
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
