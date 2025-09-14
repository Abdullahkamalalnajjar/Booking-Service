using System.Linq.Expressions;

namespace Project.Service.Implementations
{
    public class ServiceEntityService(IUnitOfWork unitOfWork) : IServiceEntityService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<string> CreateServiceAsync(ServiceEntity service, CancellationToken cancellationToken)
        {
            await _unitOfWork.Services.AddAsync(service, cancellationToken);
            await _unitOfWork.CompeleteAsync();
            return "Created";

        }

        public async Task<bool> DeleteServiceAsync(ServiceEntity service)
        {
            await _unitOfWork.Services.Delete(service);
            await _unitOfWork.CompeleteAsync();
            return true;
        }
        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync()
        {
            return await _unitOfWork.Services.GetTableNoTracking().Select(ServiceToDto).ToListAsync();
        }

        public async Task<ServiceDto?> GetServiceByIdAsync(int id)
        {
            return await _unitOfWork.Services.GetTableNoTracking().Where(x => x.Id.Equals(id)).Select(ServiceToDto).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<ServiceDto>> GetServicesByCategoryAsync(string category)
        {
            return await _unitOfWork.Services.GetTableNoTracking().Where(x => x.Category.Name.Equals(category)).Select(ServiceToDto).ToListAsync();
        }
        public Task<string> UpdateServiceAsync(ServiceEntity service)
        {
            throw new NotImplementedException();
        }
        #region  Expression to convert ServiceEntity to ServiceDto
        private static readonly Expression<Func<ServiceEntity, ServiceDto>> ServiceToDto = s => new ServiceDto
        {
            Id = s.Id,
            Description = s.Description,
            Price = s.Price,
            Name = s.Name,
            ImageUrl = s.ImageUrl,
            Location = s.Location,
            Capacity = s.Capacity,
            Policies = s.Policies,
            CategoryName = s.Category.Name,
            ServiceCategoryId = s.ServiceCategoryId,
            Features = s.Features.Select(f => new ServiceFeatureDto
            {
                Id = f.Id,
                Name = f.Name,
                Icon = f.Icon
            }).ToList(),
            Images = s.Images.Select(i => new ServiceImageDto
            {
                Id = i.Id,
                Url = i.ImageUrl
            }).ToList(),
            Packages = s.Packages.Select(p => new ServicePackageDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Items = p.Items.ToList()
            }).ToList(),


        };

        #endregion 
    }
}
