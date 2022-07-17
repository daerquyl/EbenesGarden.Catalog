namespace Catalog.Models
{
    public class Product : Entity
	{

        public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string? Description { get; set; }
		public Money? Price { get; set; }
		public Stock? Stock { get; set; }
		public Category Category { get; set; }
		public MultiSizedImage MainImage { get; set; }
		public Shop Shop { get; set; }
		public List<PaymentPolicy> PaymentPolicies { get; set; }
		public List<DeliveryPolicy> DeliveryPolicies { get; set; }
		public List<ReturnPolicy> ReturnPolicies { get; set; }
		public List<MultiSizedImage> OtherImages { get; set; } = new List<MultiSizedImage>();
		public List<ProductVariation> Variations { get; set; } = new List<ProductVariation>();
		public List<ProductImagesVariesBy> ImagesVariesBy { get; set; } = new List<ProductImagesVariesBy>();
		public Visibility Visibility { get; set; } = Visibility.Default;


        public Product(string name,
            string shortDescription,
            string description,
            Category category,
            MultiSizedImage image,
            Shop shop,
            Money price,
			Stock stock)
            : this(name, shortDescription, description, category, image, shop)
        {
            this.Price = price;
            this.Stock = Stock;
        }

        public Product(string name,
			string shortDescription,
			string description,
			Category category,
			MultiSizedImage image,
			Shop shop
			)
        {
			//Check null props
			this.Name = name;
			this.ShortDescription = ShortDescription;
			this.Description = Description;
			Category = category;
			MainImage = image;
			Shop = shop;
			Visibility = shop.Visibility;
			PaymentPolicies = shop.DefaultPaymentPolicies;
			ReturnPolicies = shop.DefaultReturnPolicies;
			DeliveryPolicies = shop.DefaultDeliveryPolicies;
		}

    }
}