namespace Project.Core.Features.Services.Queries.Models
{
    public class GetServiceByIdQuery : IRequest<Response<ServiceDto>>
    {
        public int Id { get; set; }
    }
}

