using DrinkrSocial.Domain.Entities.Models.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.DTO.Taverns
{
    public class TavernDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }    
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        //public List<TavernHappyHours> TavernHappyHours { get; set; }
        //public List<string> TavernEvents { get; set; }

    }
}
