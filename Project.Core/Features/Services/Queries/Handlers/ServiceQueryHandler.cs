using AutoMapper;
using MediatR;
using Project.Core.Bases;
using Project.Core.Features.Services.Queries.Models;
using Project.Service.Abstracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Core.Features.Services.Queries.Handlers
{
    public class ServiceQueryHandler(IMapper mapper, IServiceEntityService serviceEntityService) : ResponseHandler,
        IRequestHandler<GetAllServicesQuery, Response<IEnumerable<ServiceDto>>>,
        IRequestHandler<GetServiceByIdQuery, Response<ServiceDto>>,
        IRequestHandler<GetServicesByCategoryNameQuery, Response<IEnumerable<ServiceDto>>>


    {
        private readonly IMapper _mapper = mapper;
        private readonly IServiceEntityService _serviceEntityService = serviceEntityService;

        public async Task<Response<IEnumerable<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceEntityService.GetAllServicesAsync();
            return Success(services);
        }

        public async Task<Response<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceEntityService.GetServiceByIdAsync(request.Id);
            if (service == null) return BadRequest<ServiceDto>("service Not found");
            return Success(service);

        }

        public async Task<Response<IEnumerable<ServiceDto>>> Handle(GetServicesByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceEntityService.GetServicesByCategoryAsync(request.Name);
            if (services == null) return BadRequest<IEnumerable<ServiceDto>>("service Not found");
            return Success(services);
        }
    }
}