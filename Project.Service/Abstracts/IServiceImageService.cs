using Project.Data.Entities;

namespace Project.Service.Abstracts
{
    public interface IServiceImageService
    {
        Task<string> CreateAsync(ServiceImage image, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ServiceImage image);
        Task<ServiceImage?> GetByIdAsync(int id);
        Task<IEnumerable<ServiceImage>> GetAllAsync();
        Task<string> UpdateAsync(ServiceImage image);
    }
}