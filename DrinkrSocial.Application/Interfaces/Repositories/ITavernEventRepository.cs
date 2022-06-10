using DrinkrSocial.Domain.Entities.DTO.Taverns;
using DrinkrSocial.Domain.Entities.Models.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Interfaces.Repositories
{
    public interface ITavernEventRepository : IRepository<Event, Guid>
    {
        Task<IEnumerable<TavernEventDTO>> GetTavernEventsByTavernIdAsync(Guid tavernID);
    }
}
