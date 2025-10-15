using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Faviorts.Command.models
{
    public class AddToFavoriteCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public int ServiceId { get; set; }
    }
}
