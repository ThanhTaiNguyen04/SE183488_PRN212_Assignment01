using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        private bool isGenerated = false;
        public List<Customer> GenerateSampleDataset()
        {
            if(isGenerated) {
                return customers;
            }

            customers.Add(new Customer()
            {
                CustomerID = 1,
                CompanyName = "Công ty Thịnh Vượng",
                ContactName = "Nguyễn Thành Tài",
                ContactTitle = "Giám đốc điều hành",
                Address = "101 Lý Thường Kiệt, Q.Tân Bình",
                Phone = "0912345678"
            });

            customers.Add(new Customer()
            {
                CustomerID = 2,
                CompanyName = "CTCP An Phát",
                ContactName = "Nguyễn Thị Mai",
                ContactTitle = "Phó phòng kinh doanh",
                Address = "32 Nguyễn Văn Cừ, Q.5",
                Phone = "0912987654"
            });

            customers.Add(new Customer()
            {
                CustomerID = 3,
                CompanyName = "DNTN Hưng Thịnh",
                ContactName = "Phạm Văn Tùng",
                ContactTitle = "Nhân viên hỗ trợ",
                Address = "66 Phan Đăng Lưu, Q.Bình Thạnh",
                Phone = "0933123456"
            });

            customers.Add(new Customer()
            {
                CustomerID = 4,
                CompanyName = "Công ty Ánh Dương",
                ContactName = "Trần Thị Hồng",
                ContactTitle = "Trưởng phòng nhân sự",
                Address = "12 Trường Chinh, Q.Tân Phú",
                Phone = "0966123456"
            });

            customers.Add(new Customer()
            {
                CustomerID = 5,
                CompanyName = "CT TNHH Sao Mai",
                ContactName = "Võ Minh Long",
                ContactTitle = "Quản lý dự án",
                Address = "88 Điện Biên Phủ, Q.3",
                Phone = "0988112233"
            });

            isGenerated = true;
            return customers;
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public bool AddCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c != null)
            {
                return false;
            }

            customers.Add(customer);
            return true;
        }

        public bool RemoveCustomer(int customerId)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (c == null)
            {
                return false;
            }

            customers.Remove(c);
            return true;
        }

        public Customer SearchCustomer(int customerId)
        {
            return customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c == null)
            {
                return false;
            }

            c.CompanyName = customer.CompanyName;
            c.ContactName = customer.ContactName;
            c.ContactTitle = customer.ContactTitle;
            c.Address = customer.Address;
            c.Phone = customer.Phone;

            return true;
        }
    }
}
