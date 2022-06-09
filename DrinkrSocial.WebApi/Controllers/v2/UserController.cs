using Microsoft.AspNetCore.Mvc;

namespace DrinkrSocial.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
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
            return Ok(await Mediator.Send(new LoginCommand { UserName = username, Password = password }));
        }
    }
}
