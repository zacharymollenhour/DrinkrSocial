using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Domain.Entities.DTO;
using DrinkrSocial.Domain.Entities.Models.Users;
using DrinkrSocial.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Repositories
{
    public class UserRoleRepository : EfEntityRepository<Role, ApplicationDbContext, Guid>, IUserRoleRepository
    {
       
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserRoleDTO>> GetRolesByUserIDAsync(Guid userId)
        {
            return await _context.Roles.Where(r => r.UserRoles.Any(ur => ur.UserId == userId)).Select(role => new UserRoleDTO
            {
                Id = role.Id,
                Name = role.Name
            }).ToListAsync();
        }

       
    }
}
