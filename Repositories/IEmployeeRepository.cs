using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GenerateSampleDataset();
        public List<Employee> GetEmployees();
        public bool AddEmployee(Employee employee);
        public bool RemoveEmployee(int employeeId);
        public Employee SearchEmployee(int employeeId);
        public bool UpdateEmployee(Employee employee);
    }
}
