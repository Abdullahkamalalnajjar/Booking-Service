namespace Project.Service.Implementations
{
    public class ServiceReviewService(IUnitOfWork unitOfWork) : IServiceReviewService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateAsync(ServiceReview review, CancellationToken cancellationToken)
        {
            await _unitOfWork.ServiceReviews.AddAsync(review, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return "Created";
        }

        public async Task<bool> DeleteAsync(ServiceReview review)
        {
            await _unitOfWork.ServiceReviews.Delete(review);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<ServiceReview?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServiceReviews.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ServiceReview>> GetAllAsync()
        {
            return await _unitOfWork.ServiceReviews.GetAllAsync();
        }

        public async Task<string> UpdateAsync(ServiceReview review)
        {
            _unitOfWork.ServiceReviews.Update(review);
            await _unitOfWork.CompeleteAsync();
            return "Updated";
        }
    }
}