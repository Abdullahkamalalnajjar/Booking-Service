using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Faviorts.Queries.Models
{
    public class GetUserFavoritesQuery : IRequest<Response<List<FavoritesDto>>>
    {
        public string UserId { get; set; }
    }
}
