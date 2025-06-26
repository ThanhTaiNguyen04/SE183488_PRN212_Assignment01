using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessLayer;

namespace Services
{
    public class InputValidator : IInputValidator
    {
        private CustomerService customerService;
        private CategoryService categoryService;
        private EmployeeService employeeService;
        private ProductService productService;
        private OrderService orderService;

        private List<Customer> customers;
        private List<Category> categories;
        private List<Employee> employees;
        private List<Product> products;
        private List<Order> orders;

        public InputValidator()
        {
            customerService = CustomerService.Instance;
            categoryService = CategoryService.Instance;
            employeeService = EmployeeService.Instance;
            productService = ProductService.Instance;
            orderService = OrderService.Instance;

            customers = customerService.GetCustomers();
            categories = categoryService.GetCategories();
            employees = employeeService.GetEmployees();
            products = productService.GetProducts();
            orders = orderService.GetOrders();
        }

        public bool isPhoneValidation(string phoneNumber)
        {
            string regex = @"^(?:\+84|84|0)(3|5|7|8|9)\d{8}$";
            return Regex.IsMatch(phoneNumber, regex);
        }

        public bool IsCustomerIDExist(int customerID)
        {
            return customers.Any(c => c.CustomerID == customerID);
        }

        public bool IsCategoryIDExist(int categoryID)
        {
            return categories.Any(c => c.CategoryID == categoryID);
        }

        public bool IsEmployeeIDExist(int employeeID)
        {
            return employees.Any(e => e.EmployeeID == employeeID);
        }

        public bool IsProductIDExist(int productID)
        {
            return products.Any(p => p.ProductID == productID);
        }

        public bool IsOrderIDExist(int orderID)
        {
            return orders.Any(o => o.OrderID == orderID);
        }
    }
}
