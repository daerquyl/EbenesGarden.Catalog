using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class ReturnPolicy : Policy
    {
        public string Description { get; set; }
        public TimeType? DelayType { get; set; }
        public int? Delay { get; set; }
        public Country? Country { get; set; }
        public GeographicArea? Area { get; set; }
    }
}
