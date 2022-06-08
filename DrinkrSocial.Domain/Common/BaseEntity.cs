using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAtDateTimeUTC { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedAtDateTimeUTC { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime DeletedAtDateTimeUTC { get; set; }
        public int DeletedBy { get; set; }
    }
}
