namespace Project.Service.Implementations
{
    public class ServicePackageService(IUnitOfWork unitOfWork) : IServicePackageService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateAsync(ServicePackage package, CancellationToken cancellationToken)
        {
            await _unitOfWork.ServicePackages.AddAsync(package, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return "Created";
        }

        public async Task<bool> DeleteAsync(ServicePackage package)
        {

            await _unitOfWork.ServicePackages.Delete(package);
            await _unitOfWork.CompeleteAsync();
            return true;
        }

        public async Task<ServicePackage?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ServicePackages.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ServicePackage>> GetAllAsync()
        {
            return await _unitOfWork.ServicePackages.GetAllAsync();
        }

        public async Task<string> UpdateAsync(ServicePackage package)
        {
            _unitOfWork.ServicePackages.Update(package);
            await _unitOfWork.CompeleteAsync();
            return "Updated";
        }
    }
}