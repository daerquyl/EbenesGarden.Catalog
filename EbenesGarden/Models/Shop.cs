using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Shop : Entity
    {

        public Shop(string name, string description, string email, string tel, string managerId, Image image, Country country)
        {
            Name = name;
            Description = description;
            Email = email;
            Tel = tel;
            ManagerId = managerId;
            Image = image;
            Country = country;
            Visibility = Visibility.Default;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string ManagerId { get; set; }
        public Image Image { get; set; }
        public Country Country { get; set; }
        public List<PaymentPolicy> DefaultPaymentPolicies { get; set; }
        public List<DeliveryPolicy> DefaultDeliveryPolicies { get; set; }
        public List<ReturnPolicy> DefaultReturnPolicies { get; set; }
        public Visibility Visibility { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
