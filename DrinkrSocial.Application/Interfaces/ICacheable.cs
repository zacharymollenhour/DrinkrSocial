using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces
{
    public interface ICacheable
    {
        bool BypassCache { get; }
        string CacheKey { get; }
    }
}
