
using Microsoft.AspNetCore.Mvc;
using Project.Api.Base;
using Project.Core.Features.Faviorts.Command.models;
using Project.Core.Features.Faviorts.Queries.Models;
using Project.Data.AppMetaData;

namespace Project.Api.Controllers
{

    public class FavoritesController : AppBaseController
    {
        [HttpPost(Router.FavoritesRouting.Create)]
        public async Task<IActionResult> AddToFavorite([FromBody] AddToFavoriteCommand command, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpDelete(Router.FavoritesRouting.Delete)]
        public async Task<IActionResult> RemoveFromFavorite([FromRoute] string id, [FromRoute] int serviceId)
        {
            var command = new RemoveFromFavoriteCommand { UserId = id, ServiceId = serviceId };
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet(Router.FavoritesRouting.GetById)]
        public async Task<IActionResult> GetUserFavorites(string id)
        {
            var query = new GetUserFavoritesQuery { UserId = id };
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
