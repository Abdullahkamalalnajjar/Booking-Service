namespace Project.Data.Entities;

public class ServiceFeature
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Icon { get; set; }

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
}