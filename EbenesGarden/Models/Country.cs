using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Country: Entity
    {
        public string Name { get; set; }
        public string CountryIsoCode { get; set; }
        public GeographicArea? Area { get; set; }
    }
}
