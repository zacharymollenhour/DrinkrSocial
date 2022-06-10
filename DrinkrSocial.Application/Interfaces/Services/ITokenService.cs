using DrinkrSocial.Domain.Entities.DTO;
using DrinkrSocial.Domain.Entities.Models;
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
