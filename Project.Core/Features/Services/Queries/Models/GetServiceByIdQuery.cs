using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Services.Queries.Models
{
    public class GetServiceByIdQuery : IRequest<Response<ServiceDto>>
    {
        public int Id { get; set; }
    }
}

