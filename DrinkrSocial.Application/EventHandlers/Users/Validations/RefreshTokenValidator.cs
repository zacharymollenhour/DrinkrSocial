﻿using DrinkrSocial.Application.EventHandlers.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Validations
{
    public class RefreshTokenValidator : AbstractValidator<CreateTokenByRefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token is required");
        }
    }
}
