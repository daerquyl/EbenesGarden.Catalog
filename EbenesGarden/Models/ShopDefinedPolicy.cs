using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class ShopDefinedPolicy: Policy
    {
        public string ShopId { get; set; }
        public Policy Policy { get; set; }
        public PolicyType PolicyType { get; set; }
    }
}
