using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Services.Queries.Models
{
    public class GetServicesByCategoryNameQuery : IRequest<Response<IEnumerable<ServiceDto>>>
    {
        public string Name { get; set; }
    }
}
