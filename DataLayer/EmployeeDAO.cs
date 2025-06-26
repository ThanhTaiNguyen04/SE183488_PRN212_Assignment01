using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class EmployeeDAO
    {
        static List<Employee> employees = new List<Employee>();
        private bool isGenerated = false;
        public List<Employee> GenerateSampleDataset()
        {
            if (isGenerated) {
                return employees;
            }
            employees.Add(new Employee()
            {
                EmployeeID = 1,
                Name = "Nguyen Thanh Tai",
                UserName = "ntt01",
                Password = "123456",
                JobTitle = "Nhan vien kinh doanh",
                BirthDate = new DateTime(1995, 5, 10),
                HireDate = new DateTime(2020, 1, 15),
                Address = "123 Duong A, Quan 1"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 2,
                Name = "Tran Thi B",
                UserName = "ttb02",
                Password = "abcdef",
                JobTitle = "Ke toan truong",
                BirthDate = new DateTime(1988, 8, 22),
                HireDate = new DateTime(2015, 4, 5),
                Address = "45 Duong B, Quan 3"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 3,
                Name = "Le Van C",
                UserName = "lvc03",
                Password = "pass123",
                JobTitle = "Lap trinh vien",
                BirthDate = new DateTime(1992, 3, 18),
                HireDate = new DateTime(2018, 6, 20),
                Address = "12 Duong C, Quan 5"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 4,
                Name = "Pham Minh D",
                UserName = "pmd04",
                Password = "admin123",
                JobTitle = "Quan ly nhan su",
                BirthDate = new DateTime(1985, 11, 5),
                HireDate = new DateTime(2012, 9, 1),
                Address = "78 Duong D, Quan 10"
            });

            employees.Add(new Employee()
            {
                EmployeeID = 5,
                Name = "Doan Thi E",
                UserName = "dte05",
                Password = "securepass",
                JobTitle = "Thu ky",
                BirthDate = new DateTime(1990, 2, 28),
                HireDate = new DateTime(2019, 2, 10),
                Address = "89 Duong E, Binh Thanh"
            });
            isGenerated = true;
            return employees;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public bool AddEmployee(Employee employee)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);
            if (e != null)
            {
                return false;
            }

            employees.Add(employee);
            return true;
        }
        public bool RemoveEmployee(int employeeId)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
            if (e == null)
            {
                return false;
            }

            employees.Remove(e);
            return true;
        }

        public Employee SearchEmployee(int employeeId)
        {
            return employees.FirstOrDefault(emp => emp.EmployeeID == employeeId);
        }

        // Cap nhat thong tin nhan vien
        public bool UpdateEmployee(Employee employee)
        {
            Employee e = employees.FirstOrDefault(emp => emp.EmployeeID == employee.EmployeeID);
            if (e == null)
            {
                return false;
            }

            e.Name = employee.Name;
            e.UserName = employee.UserName;
            e.Password = employee.Password;
            e.JobTitle = employee.JobTitle;
            e.BirthDate = employee.BirthDate;
            e.HireDate = employee.HireDate;
            e.Address = employee.Address;

            return true;
        }
    }
}
