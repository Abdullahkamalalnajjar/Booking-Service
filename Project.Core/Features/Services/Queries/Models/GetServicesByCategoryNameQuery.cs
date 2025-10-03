namespace Project.Core.Features.Services.Queries.Models
{
    public class GetServicesByCategoryNameQuery : IRequest<Response<IEnumerable<ServiceDto>>>
    {
        public string Name { get; set; }
    }
}
