namespace Project.Data.Entities;

public class ServiceEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public string Policies { get; set; } = null!;
    // Owner (???? ??????)
    public string UserId { get; set; } = null!;
    public ApplicationUser user{ get; set; } = null!;


    public int ServiceCategoryId { get; set; }
    public ServiceCategory Category { get; set; } = null!;

    public ICollection<ServiceImage> Images { get; set; } = new List<ServiceImage>();
    public ICollection<ServiceFeature> Features { get; set; } = new List<ServiceFeature>();
    public ICollection<ServicePackage> Packages { get; set; } = new List<ServicePackage>();
    public ICollection<ServiceReview> Reviews { get; set; } = new List<ServiceReview>();
}