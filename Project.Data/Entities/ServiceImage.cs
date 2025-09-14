namespace Project.Data.Entities;

public class ServiceImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
}