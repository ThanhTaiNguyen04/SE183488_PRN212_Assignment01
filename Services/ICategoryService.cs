using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Services
{
    public interface ICategoryService
    {
        public List<Category> GenerateSampleDataset();
        public List<Category> GetCategories();
        public bool AddCategory(Category category);
        public bool RemoveCategory(int categoryId);
        public Category SearchCategory(int categoryId);
        public bool UpdateCategory(Category category);
    }
}
