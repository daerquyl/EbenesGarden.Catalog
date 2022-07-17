using Catalog.Models;

namespace Catalog.Tests.UnitTests
{
    public class StockFixture
    {
        public Stock AnyStock => new Stock(StockType.QUANTITY, 5);
    }

    public class MoneyFixture
    {
        public Money AnyMoney => new Money(5, Currency.EUR);
    }

    public class CategoryFixture
    {
        public CategoryFamily categoryFamily => new CategoryFamily
        {
            Id = "Category Family Id",
            Name = "Category Family",
            Description = "Category Family Description"
        };

        public Category AnyCategory => new Category
        {
            Id = "1",
            Name = "AFRICA"
        };
    }

    public class CountryFixture
    {
        public GeographicArea AnyGeographicArea => new GeographicArea
        {
            Id = "1",
            Name = "AFRICA"
        };

        public Country AnyCountry => new Country
        {
            Id = "2",
            Name = "FRANCE",
            CountryIsoCode = "FR",
            Area = AnyGeographicArea,
        };

    }

    public class ImageFixture
    {
        public Image AnyLargeImage => new Image
        (
            ImageSize.LARGE, "Url"
        );

        public Image AnyMediumImage => new Image
        (
            ImageSize.MEDIUM, "Url"
        );

        public Image AnySmallImage => new Image
        (
            ImageSize.SMALL, "Url"
        );

        public Image AnyLogoImage => new Image
        (
            ImageSize.LOGO, "Url"
        );
    }

    public class PolicyFixture
    {
        public PaymentPolicy PaymentPolicy => new PaymentPolicy
        {
            Id = "Payment Policy Id",
            PaymentType = PaymentType.PAYPAL
        };

        public List<PaymentPolicy> AnyPaymentPolicies => new List<PaymentPolicy>()
        {
            PaymentPolicy
        };

        public ReturnPolicy ReturnPolicy => new ReturnPolicy
        {
            Id = "Return Policy Id",
            Description = "Return policy description",
            DelayType = TimeType.HOUR,
            Delay = 15,
        };

        public List<ReturnPolicy> AnyReturnPolicies => new List<ReturnPolicy>()
        {
            ReturnPolicy
        };

        public DeliveryPolicy DeliveryPolicy => new DeliveryPolicy
        {
            Id = "Delivery Policy Id",
            Description = "Delivery policy description",
            DelayType = TimeType.HOUR,
            Delay = 15,
        };

        public List<DeliveryPolicy> AnyDeliveryPolicies => new List<DeliveryPolicy>()
        {
            DeliveryPolicy
        };
    }

    public class ShopFixture
    {
        private CountryFixture _countryFixture;
        private ImageFixture _imageFixture;

        public ShopFixture()
        {
            _countryFixture = new CountryFixture();
            _imageFixture = new ImageFixture();
        }

        public string AnyShopName => "Shop Name";
        public string AnyShopDescription => "Shop Description";
        public string AnyShopEmail => "shop@email.com";
        public string AnyShopTel => "337851524";
        public string AnyShopManagerId => Guid.NewGuid().ToString();

        public Shop AnyShop => new Shop(
            AnyShopName,
            AnyShopDescription,
            AnyShopEmail,
            AnyShopTel,
            AnyShopManagerId,
            _imageFixture.AnyLogoImage,
            _countryFixture.AnyCountry
        );
    }

    public class ProductFixture
    {
        private CategoryFixture _categoryFixture;
        private MoneyFixture _moneyFixture;
        private ImageFixture _imageFixture;
        private StockFixture _stockFixture;
        private ShopFixture _shopFixture;

        public ProductFixture()
        {
            _categoryFixture = new CategoryFixture();
            _moneyFixture = new MoneyFixture();
            _imageFixture = new ImageFixture();
            _stockFixture = new StockFixture();
            _shopFixture = new ShopFixture();
        }
        public string AnyProductName => "Shop Name";
        public string AnyProductShortDescription => "Shop Description";
        public string AnyProductDescription => "Shop Description";
        public MultiSizedImage AnyProductImage => new MultiSizedImage
        {
            Main = _imageFixture.AnySmallImage
        };

        public Product AnyLightProduct => new Product(
            AnyProductName,
            AnyProductShortDescription,
            AnyProductDescription,
            _categoryFixture.AnyCategory,
            AnyProductImage,
            _shopFixture.AnyShop
        );
    }
}
