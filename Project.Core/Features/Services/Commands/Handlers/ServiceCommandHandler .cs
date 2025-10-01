using Project.Core.Features.Services.Commands.Models;

public class CreateServiceCommandHandler(IServiceEntityService serviceEntityService, IMapper mapper) : ResponseHandler,
    IRequestHandler<CreateServiceCommand, Response<string>>,
    IRequestHandler<UpdateServiceCommand, Response<string>>,
    IRequestHandler<DeleteServiceCommand, Response<string>>
{
    private readonly IServiceEntityService _serviceEntityService = serviceEntityService;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<string>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var service = _mapper.Map<ServiceEntity>(request);

            var result = await _serviceEntityService.CreateServiceAsync(service, cancellationToken);
            if (result != "Created")
            {
                return BadRequest<string>("Failed to create service");
            }

            return Created("Service created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest<string>($"Error: {ex.Message}");
        }
    }
    public async Task<Response<string>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // جلب الـ Entity للتحديث
            var existing = await _serviceEntityService.GetServiceEntityByIdForUpdateAsync(request.Id);
            if (existing == null)
                return NotFound<string>("Service not found");

            // --- تحديث الحقول الأساسية ---
            if (!string.IsNullOrEmpty(request.Name))
                existing.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Description))
                existing.Description = request.Description;

            if (!string.IsNullOrEmpty(request.Location))
                existing.Location = request.Location;

            if (request.Capacity.HasValue)
                existing.Capacity = request.Capacity.Value;

            if (request.Price.HasValue)
                existing.Price = request.Price.Value;

            if (!string.IsNullOrEmpty(request.Policies))
                existing.Policies = request.Policies;

            if (request.ServiceCategoryId.HasValue)
                existing.ServiceCategoryId = request.ServiceCategoryId.Value;
            if (!string.IsNullOrEmpty(request.Deposit))
                existing.Deposit = request.Deposit;
            if (!string.IsNullOrEmpty(request.Latitude))
                existing.Latitude = request.Latitude;
            if (!string.IsNullOrEmpty(request.Longitude))
                existing.Longitude = request.Longitude;

            // --- Features: استبدال القديم بالجديد لو تم ارسال DTOs ---
            if (request.Features != null)
            {
                existing.Features = request.Features
                    .Select(f => new ServiceFeature
                    {
                        Id = f.Id,
                        Name = f.Name ?? string.Empty,
                        Icon = f.Icon,
                        ServiceId = existing.Id
                    })
                    .ToList();
            }

            // --- Packages: استبدال القديم بالجديد لو تم ارسال DTOs ---
            if (request.Packages != null)
            {
                existing.Packages = request.Packages
                    .Select(p => new ServicePackage
                    {
                        Id = p.Id,
                        Title = p.Title ?? string.Empty,
                        Price = p.Price ?? 0m,
                        ServiceId = existing.Id,
                        Items = p.Items?.Select(i => new ServicePackageItem
                        {
                            Id = i.Id,
                            Name = i.Name ?? string.Empty
                            // ServicePackageId سيُملأ تلقائياً من EF عند إضافة الكائن
                        }).ToList() ?? new List<ServicePackageItem>()
                    })
                    .ToList();
            }

            // حفظ التغييرات
            var result = await _serviceEntityService.UpdateServiceAsync(existing);
            if (result == "Updated")
                return Updated("Service updated successfully");
            return BadRequest<string>("Failed to update service");

        }
        catch (Exception ex)
        {
            return BadRequest<string>($"Error: {ex.Message}");
        }

    }

    public async Task<Response<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceEntityService.GetServiceEntityByIdForUpdateAsync(request.Id);
        if (service == null) return BadRequest<string>("Service not found");
        var result = await _serviceEntityService.DeleteServiceAsync(service);
        if (result == true) return Success<string>("deleted Successfully");
        return BadRequest<string>("Failed to Delete service");

    }
}

