using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class MultiSizedImage : Entity
    {
        public Image Main { get; set; }
        public Image? Medium { get; set; }
        public Image? Large { get; set; }
        public Image? Small { get; set; }
    }
}
