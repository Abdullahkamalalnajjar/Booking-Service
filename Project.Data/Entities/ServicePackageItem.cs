namespace Project.Data.Entities
{
    public class ServicePackageItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int ServicePackageId { get; set; }
        public ServicePackage ServicePackage { get; set; } = null!;
    }

}
