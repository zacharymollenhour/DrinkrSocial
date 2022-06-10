
using DrinkrSocial.Domain.Entities.DTO;
using DrinkrSocial.Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<UserDTO> GetUserWithRolesAsync(Guid userId);
        Task<IEnumerable<UserDTO>> GetAllUsersWithRolesAsync();
        Task<User> GetUserRolesByUserIdAsync(Guid userID);
    }
}
