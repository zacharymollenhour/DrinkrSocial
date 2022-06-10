using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models
{
    public class TokenRefresh : BaseEntity<int>
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
