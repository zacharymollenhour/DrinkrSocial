using DrinkrSocial.Application.EventHandlers.Users.Commands;
using DrinkrSocial.Application.Wrappers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkrSocial.WebApi.Controllers.v1
{
    public class UserController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("changepassword")]
        public async Task<IResponse> ChangePassword(ChangePasswordCommand command)
        {
            command.UserId = UserId.Value;
            return await _mediator.Send(command);
        }
    }
}
