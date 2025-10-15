using MediatR;
using Project.Core.Bases;
using Project.Core.Features.Faviorts.Command.models;
using Project.Data.Entities.verifyRequst;



namespace Project.Core.Features.Favorites.Commands.Handlers
{
    public class FavoriteCommandHandler : ResponseHandler,
        IRequestHandler<AddToFavoriteCommand, Response<string>>,
        IRequestHandler<RemoveFromFavoriteCommand, Response<string>>
    {
        private readonly IFavoriteServices _favoriteService;
        private readonly IMapper _mapper;

        public FavoriteCommandHandler(IFavoriteServices favoriteService, IMapper mapper)
        {
            _favoriteService = favoriteService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var message = await _favoriteService.AddToFavoriteAsync(request.UserId, request.ServiceId, cancellationToken);
            if (message == "exists")
           return BadRequest<string>("Service exist in favorites");
           return Success<string>("Service added in Favorites");
        }

        public async Task<Response<string>> Handle(RemoveFromFavoriteCommand request, CancellationToken cancellationToken)
        {
            var message = await _favoriteService.RemoveFromFavoriteAsync(request.UserId, request.ServiceId);
            if (message == "notfound")
              return BadRequest<string>("Service Not found in favorites");
            return Success<string>("Service removed");
        }
    }
}
