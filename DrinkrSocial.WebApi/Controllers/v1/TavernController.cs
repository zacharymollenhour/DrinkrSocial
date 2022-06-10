using DrinkrSocial.Application.EventHandlers.Taverns.Commands;
using DrinkrSocial.Application.Wrappers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkrSocial.WebApi.Controllers.v1
{
    public class TavernController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TavernController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost("getTavernsNearby")]
        public async Task<IResponse> GetAllTavernsNearby(GetNearbyTavernsCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
