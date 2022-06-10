using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Domain.Entities.DTO.Taverns;
using DrinkrSocial.Domain.Entities.Models.Taverns;
using DrinkrSocial.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Persistence.Repositories
{
    public class TavernRepository : EfEntityRepository<Tavern, ApplicationDbContext, Guid>, ITavernRepository
    {
        public TavernRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TavernDTO>> GetAllTavernsAsync()
        {
            return await _context.Taverns.Select(tavern => new TavernDTO
            {
                Id = tavern.Id,
                Name = tavern.Name,
                PostalCode = tavern.PostalCode,
                AddressLine1 = tavern.AddressLine1,
                AddressLine2 = tavern.AddressLine2!,
                PhoneNumber = tavern.PhoneNumber,
                City = tavern.City
            }).ToListAsync();

        }

        public async Task<IEnumerable<TavernDTO>> GetAllTavernsByPostalCodeAsync(string postalCode)
        {
            return await _context.Taverns.AsNoTracking().Where(x => x.PostalCode == postalCode).Select(tavern => new TavernDTO
            {
                Id = tavern.Id,
                Name = tavern.Name,
                PostalCode = tavern.PostalCode,
                AddressLine1 = tavern.AddressLine1,
                AddressLine2 = tavern.AddressLine2!,
                PhoneNumber = tavern.PhoneNumber,
                City = tavern.City
            }).ToListAsync();
        }

        public async Task<Tavern> GetTavernByTavernIdAsync(Guid tavernID)
        {
            return await _context.Taverns.SingleOrDefaultAsync(x => x.Id == tavernID);
        }

    }
}
