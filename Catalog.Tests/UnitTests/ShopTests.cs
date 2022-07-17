using FluentAssertions;
using Catalog.Models;
using Catalog.Tests.UnitTests;
using Moq;
using Catalog.Factories;
using Catalog.Repositories;

namespace Catalog.Tests
{
    public class ShopTests
    {
        private ShopFixture _fixture;
        private ImageFixture _imageFixture;
        private ShopFactory _shopFactory;
        private CountryFixture _countryFixture;
        private PolicyFixture _policyFixture;

        private IDistributionRepository _distributionRepository;

        public ShopTests()
        {
            _fixture = new ShopFixture();
            _imageFixture = new ImageFixture();
            _countryFixture = new CountryFixture();
            _policyFixture = new PolicyFixture();
            _distributionRepository = Mock.Of<IDistributionRepository>();
            _shopFactory = new ShopFactory(_distributionRepository);
        }

        [Fact]
        public void New_Shop_Have_Zero_Visibility()
        {
            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultDeliveryPolicies())
                .Returns(new List<DeliveryPolicy>());

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultPaymentPolicies())
                .Returns(new List<PaymentPolicy>());

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultReturnPolicies())
                .Returns(new List<ReturnPolicy>());


            var shop = _shopFactory.CreateShop(_fixture.AnyShopName,
                _fixture.AnyShopDescription,
                _fixture.AnyShopEmail,
                _fixture.AnyShopTel,
                _fixture.AnyShopManagerId,
                _imageFixture.AnyLogoImage,
                _countryFixture.AnyCountry
                );

            shop.Visibility.Value.Should().Be(0);
            shop.Visibility.Range.Should().Be(VisibilityRange.NONE);
        }

        [Fact]
        public void Create_New_Shop_Without_Default_Policies_Throw_Exception()
        {
            var createShop = () => _shopFactory.CreateShop(_fixture.AnyShopName,
                _fixture.AnyShopDescription,
                _fixture.AnyShopEmail,
                _fixture.AnyShopTel,
                _fixture.AnyShopManagerId,
                _imageFixture.AnyLogoImage,
                _countryFixture.AnyCountry
                );

            createShop.Should().Throw<InvalidOperationException>()
                .WithMessage("Cannot Create Shop without policies");
        }

        [Fact]
        public void New_Shop_Should_Have_Default_Policy()
        {
            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultDeliveryPolicies())
            .Returns(_policyFixture.AnyDeliveryPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultPaymentPolicies())
                .Returns(_policyFixture.AnyPaymentPolicies);

            Mock.Get(_distributionRepository).Setup(x => x.GetDefaultReturnPolicies())
                .Returns(_policyFixture.AnyReturnPolicies);

            var shop = _shopFactory.CreateShop(_fixture.AnyShopName,
                _fixture.AnyShopDescription,
                _fixture.AnyShopEmail,
                _fixture.AnyShopTel,
                _fixture.AnyShopManagerId,
                 _imageFixture.AnyLogoImage,
                _countryFixture.AnyCountry
                );

            shop.DefaultDeliveryPolicies.Should().Equal(_policyFixture.AnyDeliveryPolicies);
            shop.DefaultReturnPolicies.Should().Equal(_policyFixture.AnyReturnPolicies);
            shop.DefaultPaymentPolicies.Should().Equal(_policyFixture.AnyPaymentPolicies);
        }
    }
}