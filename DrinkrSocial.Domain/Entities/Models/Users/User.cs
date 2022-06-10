using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.Users
{
    public class User : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public string? EmailConfirmationCode { get; set; }
        public string? EmailConfirmedCode { get; set; }
        public string? ResetPasswordCode { get; set; }
        public string PostalCode { get; set; }

    }
}
