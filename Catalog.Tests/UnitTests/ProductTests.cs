using Catalog.Models;
using Moq;
using FluentAssertions;
using Catalog.Factories;
using Catalog.Repositories;

namespace Catalog.Tests.UnitTests
{
    public class ProductTests
    {
        private ProductFixture _fixture;
        private ImageFixture _imageFixture;
        private CountryFixture _countryFixture;
        private CategoryFixture _categoryFixture;
        private ShopFixture _shopFixture;
        private PolicyFixture _policyFixture;
        private ProductFactory _productFactory;
        private ShopFactory _shopFactory;
        private IDistributionRepository _distributionRepository;

        public ProductTests()
        {
            _fixture = new ProductFixture();
            _imageFixture = new ImageFixture();
            _countryFixture = new CountryFixture();
            _categoryFixture = new CategoryFixture();
            _shopFixture = new ShopFixture();
            _policyFixture = new PolicyFixture();
            _productFactory = new ProductFactory();
            _distributionRepository = Mock.Of<IDistributionRepository>();
            _shopFactory = new ShopFactory(_distributionRepository);


        }

        [Fact]
        public void New_Product_Have_Shop_Visibility()
        {
            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultDeliveryPolicies())
                .Returns(_policyFixture.AnyDeliveryPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultPaymentPolicies())
                .Returns(_policyFixture.AnyPaymentPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultReturnPolicies())
                .Returns(_policyFixture.AnyReturnPolicies);

            var shop = _shopFactory.CreateShop(_shopFixture.AnyShopName,
                _shopFixture.AnyShopDescription,
                _shopFixture.AnyShopEmail,
                _shopFixture.AnyShopTel,
                _shopFixture.AnyShopManagerId,
                 _imageFixture.AnyLogoImage,
                _countryFixture.AnyCountry
                );

            var product = new Product(
                _fixture.AnyProductName,
                _fixture.AnyProductShortDescription,
                _fixture.AnyProductDescription,
                _categoryFixture.AnyCategory,
                _fixture.AnyProductImage,
                shop);

            product.Visibility.Value.Should().Be(0);
            product.Visibility.Range.Should().Be(VisibilityRange.NONE);
        }

        public void New_Product_Have_Shop_Policies()
        {
            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultDeliveryPolicies())
                .Returns(_policyFixture.AnyDeliveryPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultPaymentPolicies())
                .Returns(_policyFixture.AnyPaymentPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultReturnPolicies())
                .Returns(_policyFixture.AnyReturnPolicies);

            var shop = _shopFactory.CreateShop(_shopFixture.AnyShopName,
                _shopFixture.AnyShopDescription,
                _shopFixture.AnyShopEmail,
                _shopFixture.AnyShopTel,
                _shopFixture.AnyShopManagerId,
                 _imageFixture.AnyLogoImage,
                _countryFixture.AnyCountry
                );

            var product = new Product(
                _fixture.AnyProductName,
                _fixture.AnyProductShortDescription,
                _fixture.AnyProductDescription,
                _categoryFixture.AnyCategory,
                _fixture.AnyProductImage,
                shop);

            product.DeliveryPolicies.Should().Equal(_policyFixture.AnyDeliveryPolicies);
            product.ReturnPolicies.Should().Equal(_policyFixture.AnyReturnPolicies);
            product.PaymentPolicies.Should().Equal(_policyFixture.AnyPaymentPolicies);
        }
    }
}
