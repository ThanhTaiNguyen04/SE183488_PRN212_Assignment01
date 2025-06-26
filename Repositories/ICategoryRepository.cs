using System.Collections.Generic;
using BusinessLayer;

namespace Repositories
{
    public interface ICategoryRepository
    {
        public bool AddCategory(Category category);
        public bool RemoveCategory(int categoryId);
        public bool UpdateCategory(Category category);
        public Category SearchCategory(int categoryId);
        public List<Category> GetCategories();
        public List<Category> GenerateSampleDataset();
    }
}
