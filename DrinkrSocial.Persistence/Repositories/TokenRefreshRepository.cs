using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Repositories
{
    public class TokenRefreshRepository : EfEntityRepository<RefreshToken, CAContext, int>, IRefreshTokenRepository
    {
        public TokenRefreshRepository(CAContext context) : base(context)
        {

        }
    }
}
