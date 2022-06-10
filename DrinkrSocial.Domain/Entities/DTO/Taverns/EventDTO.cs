using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.DTO.Taverns
{
    public class EventDTO
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsOpenToPublic { get; set; }
        public double AdmissionPrice { get; set; }
        public virtual ICollection<TavernEventDTO> TavernEvents { get; set; }
    }
}
