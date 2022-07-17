using Catalog.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data
{
    public static class ServiceCollection
    {
        public static void AddCatalogDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseMySQL(connectionString);
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
