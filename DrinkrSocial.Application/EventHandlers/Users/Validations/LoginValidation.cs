using DrinkrSocial.Application.EventHandlers.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Validations
{
    public class LoginValidation : AbstractValidator<LoginCommand>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName Is Required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Is Required");

        }
    }
}
