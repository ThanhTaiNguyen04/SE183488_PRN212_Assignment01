using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Repositories
{
    public interface IProductRepository
    {
        public List<Product> GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool AddProduct(Product product);
        public bool RemoveProduct(int productId);
        public Product SearchProduct(int productId);
        public bool UpdateProduct(Product product);
    }
}
