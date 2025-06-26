using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();

        public bool AddProduct(Product product)
        {
            return productDAO.AddProduct(product);
        }

        public List<Product> GenerateSampleDataset()
        {
            return productDAO.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public bool RemoveProduct(int productId)
        {
            return productDAO.RemoveProduct(productId);
        }

        public Product SearchProduct(int productId)
        {
            return productDAO.SearchProduct(productId);
        }

        public bool UpdateProduct(Product product)
        {
            return productDAO.UpdateProduct(product);
        }
    }
}
