namespace Project.Core.Features.Services.Commands.Models
{
    public class DeleteServiceCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

    }
}
