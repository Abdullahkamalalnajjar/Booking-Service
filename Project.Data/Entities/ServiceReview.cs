namespace Project.Data.Entities;

public class ServiceReview
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int ServiceId { get; set; }
    public ServiceEntity Service { get; set; } = null!;
}