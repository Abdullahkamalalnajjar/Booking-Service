using Project.Core.Features.Services.Commands.Models;

public class CreateServiceCommandHandler(IServiceEntityService serviceEntityService, IMapper mapper) : ResponseHandler,
    IRequestHandler<CreateServiceCommand, Response<string>>
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
}