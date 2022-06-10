using DrinkrSocial.Domain.Entities.Base;
using DrinkrSocial.Domain.Entities.DTO.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.Taverns
{
    public class Event : BaseEntity<Guid>
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
