using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Services
{
    public interface ICustomerService
    {
        public List<Customer> GenerateSampleDataset();
        public List<Customer> GetCustomers();
        public bool AddCustomer(Customer customer);
        public bool RemoveCustomer(int customerId);
        public Customer SearchCustomer(int customerId);
        public bool UpdateCustomer(Customer customer);
    }
}
