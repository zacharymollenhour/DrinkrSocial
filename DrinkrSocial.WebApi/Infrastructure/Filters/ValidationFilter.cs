using DrinkrSocial.Application.Wrappers.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DrinkrSocial.WebApi.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                var errorsReponse = new ErrorResponse(400, errors);

                context.Result = new BadRequestObjectResult(errorsReponse);
                return;

            }

            await next();
        }
    }
}
