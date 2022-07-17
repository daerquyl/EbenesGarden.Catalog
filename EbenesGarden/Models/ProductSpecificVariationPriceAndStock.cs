using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class ProductSpecificVariationPriceAndStock
	{
		public Variation Variation { get; set; }
		public String Value { get; set; }
		public Money? Price { get; set; }
		public Stock? Stock { get; set; }
    }
}
