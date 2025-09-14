namespace Project.Service.Abstracts
{
    public interface IServiceEntityService
    {
        Task<string> CreateServiceAsync(ServiceEntity service, CancellationToken cancellationToken);
        Task<string> UpdateServiceAsync(ServiceEntity service);
        Task<bool> DeleteServiceAsync(ServiceEntity service);
        Task<ServiceDto?> GetServiceByIdAsync(int id);
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
        Task<IEnumerable<ServiceDto>> GetServicesByCategoryAsync(string category);
    }

}
