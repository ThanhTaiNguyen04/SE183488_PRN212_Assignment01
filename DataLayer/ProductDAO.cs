using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        private bool isGenerated = false;
        public List<Product> GenerateSampleDataset()
        {
            if (isGenerated) {
                return products;
            }

            products.Add(new Product()
            {
                ProductID = 1,
                ProductName = "Soda",
                SupplierID = 1,
                CategoryID = 1,
                QuantityPerUnit = 10,
                UnitPrice = 18,
                UnitsInStock = 39,
                UnitsOnOrder = 0,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 2,
                ProductName = "Nam Ngu",
                SupplierID = 2,
                CategoryID = 1,
                QuantityPerUnit = 24,
                UnitPrice = 19,
                UnitsInStock = 17,
                UnitsOnOrder = 40,
                ReorderLevel = 25,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 3,
                ProductName = "Syrup",
                SupplierID = 3,
                CategoryID = 2,
                QuantityPerUnit = 12,
                UnitPrice = 10,
                UnitsInStock = 13,
                UnitsOnOrder = 70,
                ReorderLevel = 5,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 4,
                ProductName = "Gia Vi",
                SupplierID = 4,
                CategoryID = 2,
                QuantityPerUnit = 48,
                UnitPrice = 22,
                UnitsInStock = 53,
                UnitsOnOrder = 0,
                ReorderLevel = 0,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 5,
                ProductName = "Banh Mi",
                SupplierID = 5,
                CategoryID = 3,
                QuantityPerUnit = 16,
                UnitPrice = 25,
                UnitsInStock = 120,
                UnitsOnOrder = 0,
                ReorderLevel = 15,
                Discontinued = true
            });

            isGenerated = true;
            return products;

        }
        public List<Product> GetProducts ()
        {
            return products;
        }
        public bool AddProduct (Product product)
        {
            Product p = products.FirstOrDefault(p=> p.ProductID == product.ProductID);

            if (p == null) { 
                return false;
            }

            products.Add(p);
            return true;
        }

        public bool RemoveProduct(int pId) {
            Product p = products.FirstOrDefault(p => p.ProductID == pId);
            if (p == null) {
                return false;
            }
            products.Remove(p);
            return true;
        }

        public Product SearchProduct(int pId) { 
            return products.FirstOrDefault(p => p.ProductID==pId);
        }

        public bool UpdateProduct(Product product) {
            Product p = products.FirstOrDefault(p => p.ProductID == product.ProductID);

            if (p == null) {
                return false;
            }

            p.ProductID = product.ProductID;
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.QuantityPerUnit = product.QuantityPerUnit;
            p.UnitsInStock = product.UnitsInStock;
            p.CategoryID = product.CategoryID;
            p.Discontinued = product.Discontinued;
            p.ReorderLevel = product.ReorderLevel;
            p.SupplierID = product.SupplierID;
            p.UnitsOnOrder = product.UnitsOnOrder;

            return true;
        }
    }
}
