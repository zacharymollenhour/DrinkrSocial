using DrinkrSocial.Application.EventHandlers.Users.Commands;
using DrinkrSocial.Application.Wrappers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkrSocial.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Controller Endpoint to handle Authentication/User Login
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IResponse> Login(LoginCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Controller Endpoint to handle Registration for New Users
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IResponse> Register(UserRegistrationCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Controller Endpoint to handle Refreshing a Bearer Auth Token
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("refreshtoken")]
        public async Task<IResponse> RefreshToken(CreateTokenByRefreshTokenCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
