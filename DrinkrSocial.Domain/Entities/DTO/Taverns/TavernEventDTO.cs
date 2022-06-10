using DrinkrSocial.Domain.Entities.Base;
using DrinkrSocial.Domain.Entities.Models.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.DTO.Taverns
{
    public class TavernEventDTO
    {
        public Guid TavernId { get; set; }
        public Guid EventId { get; set; }
        public virtual Tavern Tavern { get; set; }
        public virtual EventDTO Event { get; set; }
    }
}
