using Catalog.Models;
using Catalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryFamily?> AddCategoryFamily(CategoryFamily family)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryFamily(string categoryFamilyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryFamily>> GetCategoriesFamilies()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoryChildren(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryFamily?> GetCategoryFamily(string categoryFamilyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryFamily(CategoryFamily categoryFamily)
        {
            throw new NotImplementedException();
        }
    }
}
