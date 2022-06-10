using DrinkrSocial.Domain.Entities.DTO.Users;
using DrinkrSocial.Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Services
{
    public interface ITokenService
    {
        TokenDTO CreateToken(User user, List<string> roles);
    }
}
