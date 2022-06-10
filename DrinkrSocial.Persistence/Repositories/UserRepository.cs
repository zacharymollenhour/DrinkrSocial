using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Domain.Entities.DTO;
using DrinkrSocial.Domain.Entities.Models;
using DrinkrSocial.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Repositories
{
    public class UserRepository : EfEntityRepository<User, ApplicationDbContext, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersWithRolesAsync()
        {
            return await _context.Users.AsNoTracking().Select(user => new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            }).ToListAsync();
        }

        public Task<IEnumerable<UserDTO>> GetALlUsersWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserRolesByUserIdAsync(Guid userid)
        {
            return await _context.Users.Include(u => u.UserRoles).SingleOrDefaultAsync(u => u.Id == userid);
        }

        public async Task<UserDTO> GetUserWithRolesAsync(Guid userid)
        {
            return await _context.Users.AsNoTracking().Select(user => new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            }).FirstOrDefaultAsync(user => user.Id == userid);
        }
    }
}
