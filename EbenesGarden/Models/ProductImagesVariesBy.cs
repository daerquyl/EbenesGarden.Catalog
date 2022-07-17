using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class ProductImagesVariesBy
    {
        public MultiSizedImage Image { get; set; }
        public ProductSpecificVariationPriceAndStock SpecificVariation { get; set; }
    }
}
