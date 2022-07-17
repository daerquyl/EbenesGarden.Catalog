using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Image: Entity
    {
        private ImageSize lARGE;
        private string v;

        public Image(ImageSize lARGE, string v)
        {
            this.lARGE = lARGE;
            this.v = v;
        }

        public ImageSize Size { get; set; }
        public string Url { get; set; }
    }
}
