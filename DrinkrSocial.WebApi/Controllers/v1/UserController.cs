using DrinkrSocial.Application.Features.UserFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DrinkrSocial.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {

        /// <summary>
        /// Controller to handle User Authentication of existing accounts
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            return Ok(await Mediator.Send(new UserLoginQuery { UserName = username, Password = password }));
        }
    }
}
