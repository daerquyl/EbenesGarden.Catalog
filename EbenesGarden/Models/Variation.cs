namespace Catalog.Models
{
    public class Variation : Entity
    {
        public string Name { get; set; }
    }

    public class StandardVariation : Variation
    {
        public string Name { get; set; }
    }

    public class DynamicVariation : Variation
    {
        public string Name { get; set; }
    }
}