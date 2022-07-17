using Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data
{
    public class CatalogDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}