using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Implementations
{
    public class FavoriteServices : IFavoriteServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<string> AddToFavoriteAsync(string userId, int serviceId ,CancellationToken cancellationToken)
        {
            var favoriteRepo = _unitOfWork.favoritesService;

            var exists = await favoriteRepo.GetTableNoTracking()
                .AnyAsync(f => f.UserId == userId.ToString() && f.ServiceId == serviceId);

            if (exists)
                return "exists";

            var favorite = new UserFavorite
            {
                UserId = userId.ToString(),
                ServiceId = serviceId
            };

            await favoriteRepo.AddAsync(favorite ,cancellationToken);
            await _unitOfWork.CompeleteAsync();

            return "added";
        }

        public async Task<string> RemoveFromFavoriteAsync(string userId, int serviceId)
        {
            var favoriteRepo = _unitOfWork.favoritesService;
            var favorite = await favoriteRepo
                .GetTableAsTracking()
                .FirstOrDefaultAsync(f => f.UserId == userId.ToString() && f.ServiceId == serviceId);
            if (favorite == null)
             return "notfound";
            favoriteRepo.Delete(favorite);
            await _unitOfWork.CompeleteAsync();
            return "removed";
        }
        public async Task<List<FavoritesDto>> GetFavoriteServicesAsync(string userId)
        {
            var favoriteRepo = _unitOfWork.favoritesService;

            var favorites = await favoriteRepo
                .GetTableNoTracking()
                .Where(f => f.UserId == userId)
                .Include(f => f.Service)
                 .Select(f => new FavoritesDto
                 {
                     Id = f.Service.Id,
                     Name = f.Service.Name
                 })
                .ToListAsync();
            return favorites;
        }  

    }
}