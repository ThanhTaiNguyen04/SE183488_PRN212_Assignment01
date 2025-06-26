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

            products.Clear();
            products.Add(new Product()
            {
                ProductID = 1,
                ProductName = "Trà Sữa Matcha",
                SupplierID = 1,
                CategoryID = 1, // Thực phẩm đóng hộp
                QuantityPerUnit = 20,
                UnitPrice = 28,
                UnitsInStock = 45,
                UnitsOnOrder = 10,
                ReorderLevel = 20,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 2,
                ProductName = "Nước Mắm Phú Quốc",
                SupplierID = 2,
                CategoryID = 2, // Gia dụng
                QuantityPerUnit = 12,
                UnitPrice = 35,
                UnitsInStock = 30,
                UnitsOnOrder = 15,
                ReorderLevel = 10,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 3,
                ProductName = "Dầu Gội Clear",
                SupplierID = 3,
                CategoryID = 3, // Chăm sóc cá nhân
                QuantityPerUnit = 18,
                UnitPrice = 50,
                UnitsInStock = 60,
                UnitsOnOrder = 0,
                ReorderLevel = 20,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 4,
                ProductName = "Cam Sành",
                SupplierID = 4,
                CategoryID = 4, // Trái cây & Rau củ
                QuantityPerUnit = 24,
                UnitPrice = 40,
                UnitsInStock = 80,
                UnitsOnOrder = 25,
                ReorderLevel = 30,
                Discontinued = false
            });

            products.Add(new Product()
            {
                ProductID = 5,
                ProductName = "Bánh Quy OREO",
                SupplierID = 5,
                CategoryID = 5, // Đồ ăn nhanh
                QuantityPerUnit = 10,
                UnitPrice = 33,
                UnitsInStock = 100,
                UnitsOnOrder = 0,
                ReorderLevel = 25,
                Discontinued = false
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

            if (p != null) {
                return false;
            }

            products.Add(product);
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
