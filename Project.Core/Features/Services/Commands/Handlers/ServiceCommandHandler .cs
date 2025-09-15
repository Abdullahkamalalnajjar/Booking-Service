using Project.Core.Features.Services.Commands.Models;

public class CreateServiceCommandHandler(
    IServiceEntityService serviceEntityService,
    IHttpContextAccessor httpContextAccessor
) : ResponseHandler,
    IRequestHandler<CreateServiceCommand, Response<string>>
{
    private readonly IServiceEntityService _serviceEntityService = serviceEntityService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<Response<string>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // ✅ الصورة الرئيسية
            string? mainImageUrl = null;
            if (request.Image != null)
            {
                mainImageUrl = FileHelper.SaveFile(request.Image, "Services", _httpContextAccessor);
            }

            var service = new ServiceEntity
            {
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                Capacity = request.Capacity,
                Price = request.Price,
                Policies = request.Policies ?? string.Empty,
                ImageUrl = mainImageUrl ?? string.Empty,
                ServiceCategoryId = request.ServiceCategoryId,
                UserId = request.UserId,
                Images = new List<ServiceImage>(),
                Features = new List<ServiceFeature>(),
                Packages = new List<ServicePackage>()
            };

            // ✅ صور إضافية
            if (request.Images != null && request.Images.Any())
            {
                foreach (var img in request.Images)
                {
                    var url = FileHelper.SaveFile(img, "Services", _httpContextAccessor);
                    if (!string.IsNullOrEmpty(url))
                        service.Images.Add(new ServiceImage { ImageUrl = url });
                }
            }

            // ✅ الخدمات الأساسية
            if (request.Features != null && request.Features.Any())
            {
                foreach (var feature in request.Features)
                {
                    if (!string.IsNullOrWhiteSpace(feature))
                        service.Features.Add(new ServiceFeature { Name = feature });
                }
            }

            // ✅ الباقات
            if (request.Packages != null && request.Packages.Any())
            {
                foreach (var pkg in request.Packages)
                {
                    if (!string.IsNullOrWhiteSpace(pkg.Title))
                    {
                        service.Packages.Add(new ServicePackage
                        {
                            Title = pkg.Title,
                            Price = pkg.Price,
                            Items = pkg.Items ?? new List<string>()
                        });
                    }
                }
            }

            // ✅ الحفظ
            var result = await _serviceEntityService.CreateServiceAsync(service, cancellationToken);

            return Created("Service created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest<string>($"Error: {ex.Message}");
        }
    }
}