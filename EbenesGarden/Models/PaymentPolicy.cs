using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class PaymentPolicy : Policy
    {
        public PaymentType PaymentType { get; set; }
    }
}
