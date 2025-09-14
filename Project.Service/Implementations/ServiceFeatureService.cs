namespace Project.Service.Implementations
{
    public class ServiceFeatureService(IUnitOfWork unitOfWork) : IServiceFeatureService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateAsync(ServiceFeature feature, CancellationToken cancellationToken)
        {
            await _unitOfWork.ServiceFeatures.AddAsync(feature, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return "Created";
        }

        public async Task<bool> DeleteAsync(ServiceFeature entity)
        {
            await _unitOfWork.ServiceFeatures.Delete(entity);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<ServiceFeature?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServiceFeatures.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ServiceFeature>> GetAllAsync()
        {
            return await _unitOfWork.ServiceFeatures.GetAllAsync();
        }

        public async Task<string> UpdateAsync(ServiceFeature feature)
        {
            _unitOfWork.ServiceFeatures.Update(feature);
            await _unitOfWork.CompeleteAsync();
            return "Updated";
        }


    }
}