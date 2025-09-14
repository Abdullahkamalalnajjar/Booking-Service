namespace Project.Service.Abstracts
{
    public interface IServicePackageService
    {
        public Task<string> CreateAsync(ServicePackage package, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ServicePackage package);
        Task<ServicePackage?> GetByIdAsync(int id);
        Task<IEnumerable<ServicePackage>> GetAllAsync();
        Task<string> UpdateAsync(ServicePackage package);
    }
}