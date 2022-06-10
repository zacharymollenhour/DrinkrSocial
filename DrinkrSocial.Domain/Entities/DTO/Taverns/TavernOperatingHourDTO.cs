using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Entities.DTO.Taverns
{
    public class TavernOperatingHourDTO
    {
        public Guid OperatingHoursId { get; set; }
        public Guid TavernId { get; set; }
        public int Day { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
    }
}
