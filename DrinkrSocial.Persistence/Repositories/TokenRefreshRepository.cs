using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Domain.Entities.Models;
using DrinkrSocial.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Repositories
{
    public class TokenRefreshRepository : EfEntityRepository<TokenRefresh, ApplicationDbContext, int>, ITokenRefreshRepository
    {
        public TokenRefreshRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
