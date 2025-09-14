namespace Project.Service.Implementations
{
    public class ServiceImageService(IUnitOfWork unitOfWork) : IServiceImageService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateAsync(ServiceImage image, CancellationToken cancellationToken)
        {
            await _unitOfWork.ServiceImages.AddAsync(image, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return "Created";
        }

        public async Task<bool> DeleteAsync(ServiceImage image)
        {
            await _unitOfWork.ServiceImages.Delete(image);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<ServiceImage?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServiceImages.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ServiceImage>> GetAllAsync()
        {
            return await _unitOfWork.ServiceImages.GetAllAsync();
        }

        public async Task<string> UpdateAsync(ServiceImage image)
        {
            _unitOfWork.ServiceImages.Update(image);
            await _unitOfWork.CompeleteAsync();
            return "Updated";
        }
    }
}