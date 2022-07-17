using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Category>> GetCategoryChildren(string categoryId);
        Task<CategoryFamily?> GetCategoryFamily(string categoryFamilyId);
        Task<Category?> GetCategory(string categoryId);
        Task<IEnumerable<CategoryFamily>> GetCategoriesFamilies();
        Task<Category> AddCategory(Category category);
        Task<CategoryFamily?> AddCategoryFamily(CategoryFamily family);
        Task UpdateCategory(Category category);
        Task UpdateCategoryFamily(CategoryFamily categoryFamily);
        Task DeleteCategory(string categoryId);
        Task DeleteCategoryFamily(string categoryFamilyId);
    }
}
