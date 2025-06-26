using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();

        public bool AddEmployee(Employee employee)
        {
            return employeeDAO.AddEmployee(employee);
        }

        public List<Employee> GenerateSampleDataset()
        {
            return employeeDAO.GenerateSampleDataset();
        }

        public List<Employee> GetEmployees()
        {
            return employeeDAO.GetEmployees();
        }

        public bool RemoveEmployee(int employeeId)
        {
            return employeeDAO.RemoveEmployee(employeeId);
        }

        public Employee SearchEmployee(int employeeId)
        {
            return employeeDAO.SearchEmployee(employeeId);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return employeeDAO.UpdateEmployee(employee);
        }
    }
}
