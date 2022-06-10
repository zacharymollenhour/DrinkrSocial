using DrinkrSocial.Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Repositories
{
    public interface ITokenRefreshRepository : IRepository<TokenRefresh, int>
    {

    }
}
