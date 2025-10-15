using MediatR;
using Project.Core.Bases;
using Project.Core.Features.Faviorts.Queries.Models;

namespace Project.Core.Features.Favorites.Queries.Handlers
{
    public class FavoriteQueryHandler
      : IRequestHandler<GetUserFavoritesQuery, Response<List<FavoritesDto>>>
    {
        private readonly IFavoriteServices _favoriteService;

        public FavoriteQueryHandler(IFavoriteServices favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<Response<List<FavoritesDto>>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
        {
            var favorites = await _favoriteService.GetFavoriteServicesAsync(request.UserId);
            return new Response<List<FavoritesDto>>(favorites);
        }
    }
}
