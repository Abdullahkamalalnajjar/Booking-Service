namespace Project.Service.Abstracts
{
    public interface IServiceReviewService
    {
        Task<string> CreateAsync(ServiceReview review, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ServiceReview review);
        Task<ServiceReview?> GetByIdAsync(int id);
        Task<IEnumerable<ServiceReview>> GetAllAsync();
        Task<string> UpdateAsync(ServiceReview review);
    }
}