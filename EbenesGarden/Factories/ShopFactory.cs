
using Catalog.Models;
using Catalog.Repositories;

namespace Catalog.Factories
{
    public class ShopFactory
    {
        private readonly IDistributionRepository _distributionRepository;

        public ShopFactory(IDistributionRepository distributionRepository)
        {
            _distributionRepository = distributionRepository;
        }

        public Shop CreateShop(string name,
            string description,
            string email,
            string tel,
            string managerId,
            Image image,
            Country country)
        {
            var shop = new Shop(name, description, email, tel, managerId, image, country);

            var defaultDeliveryPolicies = _distributionRepository.GetDefaultDeliveryPolicies(); 
            var defaultReturnPolicies = _distributionRepository.GetDefaultReturnPolicies(); 
            var defaultPaymentPolicies = _distributionRepository.GetDefaultPaymentPolicies(); 

            if(defaultDeliveryPolicies == null
                || defaultReturnPolicies == null
                || defaultPaymentPolicies == null)
            {
                throw new InvalidOperationException("Cannot Create Shop without policies");
            }

            shop.DefaultPaymentPolicies = defaultPaymentPolicies;
            shop.DefaultReturnPolicies = defaultReturnPolicies;
            shop.DefaultDeliveryPolicies = defaultDeliveryPolicies;

            return shop;
        }
    }
}