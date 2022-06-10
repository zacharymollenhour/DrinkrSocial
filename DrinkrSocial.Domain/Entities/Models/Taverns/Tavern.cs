using DrinkrSocial.Domain.Entities.Base;
using DrinkrSocial.Domain.Entities.DTO.Taverns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.Taverns
{
    public class Tavern : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Guid StateId { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
