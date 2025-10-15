using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EF.Repositories
{
    public class FavoriteRespository : GenericRepository<UserFavorite>, IFavoriteRespository
    {
        public FavoriteRespository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
