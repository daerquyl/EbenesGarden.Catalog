using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class ProductVariation
	{
		public Variation Variation { get; set; }
		public List<String> Values { get; set; }
    }
}
