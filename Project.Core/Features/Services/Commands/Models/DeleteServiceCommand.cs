using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Features.Services.Commands.Models
{
    public class DeleteServiceCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

    }
}
