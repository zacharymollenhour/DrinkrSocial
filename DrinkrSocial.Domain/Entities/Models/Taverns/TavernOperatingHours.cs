using DrinkrSocial.Domain.Entities.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.Models.Taverns
{
    public class TavernOperatingHours
    {
        public Guid OperatingHoursId { get; set; }
        public Guid TavernId { get; set; }
        public Guid DayId { get; set; }
        public virtual ICollection<DayInWeek> Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
    }
}
