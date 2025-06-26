using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private static CustomerService _instance;
        private static readonly object _lock = new object();
        private readonly ICustomerRepository icustomerRepository;
        private CustomerService()
        {
            icustomerRepository = new CustomerRepository();
        }
        public static CustomerService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new CustomerService();
                        }
                    }
                }
                return _instance;
            }
        }
        public bool AddCustomer(Customer customer)
        {
            return icustomerRepository.AddCustomer(customer);
        }

        public List<Customer> GenerateSampleDataset()
        {
            return icustomerRepository.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
            return icustomerRepository.GetCustomers();
        }

        public bool RemoveCustomer(int customerId)
        {
            return icustomerRepository.RemoveCustomer(customerId);
        }

        public Customer SearchCustomer(int customerId)
        {
            return icustomerRepository.SearchCustomer(customerId);
        }


        public bool UpdateCustomer(Customer customer)
        {
            return icustomerRepository.UpdateCustomer(customer);
        }

    }
}
