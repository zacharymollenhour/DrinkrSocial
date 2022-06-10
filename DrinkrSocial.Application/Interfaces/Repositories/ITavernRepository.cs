using DrinkrSocial.Domain.Entities.DTO.Taverns;
using DrinkrSocial.Domain.Entities.Models.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Repositories
{
    public interface ITavernRepository : IRepository<Tavern, Guid>
    {
        Task<IEnumerable<TavernDTO>> GetAllTavernsByPostalCodeAsync(string postalCode);
        Task<IEnumerable<TavernDTO>> GetAllTavernsAsync();
        Task<Tavern> GetTavernByTavernIdAsync(Guid tavernID);
    }
}
