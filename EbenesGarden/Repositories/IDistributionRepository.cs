using Catalog.Models;

namespace Catalog.Repositories
{
    public interface IDistributionRepository
    {
        List<DeliveryPolicy> GetDefaultDeliveryPolicies();
        List<ReturnPolicy> GetDefaultReturnPolicies();
        List<PaymentPolicy> GetDefaultPaymentPolicies();
    }
}