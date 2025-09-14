namespace Project.Service.Abstracts
{
    public interface IServiceFeatureService
    {
        Task<string> CreateAsync(ServiceFeature feature, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ServiceFeature serviceFeature);
        Task<ServiceFeature?> GetByIdAsync(int id);
        Task<IEnumerable<ServiceFeature>> GetAllAsync();
        Task<string> UpdateAsync(ServiceFeature feature);
    }
}