using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Category : Entity
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public Category? Parent { get; set; }
        public List<CategoryFamily> Categories { get; set; } = new List<CategoryFamily>();
    }
}
