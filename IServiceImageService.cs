using Project.Data.Entities;

namespace Project.Service.Abstracts
{
    public interface IServiceImageService
    {
        Task<int> CreateAsync(ServiceImage image);
        Task<bool> DeleteAsync(int id);
        Task<ServiceImage?> GetByIdAsync(int id);
        Task<IEnumerable<ServiceImage>> GetAllAsync();
        Task<int> UpdateAsync(ServiceImage image);
    }
}