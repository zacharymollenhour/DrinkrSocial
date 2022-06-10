using DrinkrSocial.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.Calendar
{
    public class DayInWeek : BaseEntity<Guid>
    {
        public string DayName { get; set; }

    }
}
