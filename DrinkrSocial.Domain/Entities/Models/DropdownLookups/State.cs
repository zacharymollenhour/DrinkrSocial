using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.DropdownLookups
{
    public class State : BaseEntity<Guid>
    {
        public string StateNameEN { get; set; }
        public string StateNameES { get; set; }
    }
}
