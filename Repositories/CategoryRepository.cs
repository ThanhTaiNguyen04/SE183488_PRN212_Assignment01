using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        public bool AddCategory(Category category)
        {
            return categoryDAO.AddCategory(category);
        }

        public List<Category> GenerateSampleDataset()
        {
            return categoryDAO.GenerateSampleDataset();
        }

        public List<Category> GetCategories()
        {
            return categoryDAO.GetCategories();
        }

        public bool RemoveCategory(int categoryId)
        {
            return categoryDAO.RemoveCategory(categoryId);
        }

        public Category SearchCategory(int categoryId)
        {
            return categoryDAO.SearchCategory(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            return categoryDAO.UpdateCategory(category);
        }
    }
}
