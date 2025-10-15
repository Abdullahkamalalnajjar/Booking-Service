using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Abstracts
{
    public interface IFavoriteServices
    {
        Task<string> AddToFavoriteAsync( string userId, int serviceId, CancellationToken cancellationToken);
        Task<string> RemoveFromFavoriteAsync(string userId, int serviceId);
        Task<List<FavoritesDto>> GetFavoriteServicesAsync(string userId);

    }
}
    