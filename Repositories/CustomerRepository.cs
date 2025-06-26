using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        CustomerDAO customerDAO = new CustomerDAO();
        public bool AddCustomer(Customer customer)
        {
            return customerDAO.AddCustomer(customer);
        }

        public List<Customer> GenerateSampleDataset()
        {
            return customerDAO.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
            return customerDAO.GetCustomers();
        }

        public bool RemoveCustomer(int customerId)
        {
            return customerDAO.RemoveCustomer(customerId);
        }

        public Customer SearchCustomer(int customerId)
        {
            return customerDAO.SearchCustomer(customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return customerDAO.UpdateCustomer(customer);
        }
    }
}
