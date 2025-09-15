namespace Project.Data.Entities;

public class ServicePackage
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;

    public ICollection<ServicePackageItem> Items { get; set; } = new List<ServicePackageItem>();
}
