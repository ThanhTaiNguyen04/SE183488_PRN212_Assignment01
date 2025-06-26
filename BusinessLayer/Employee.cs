using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return EmployeeID + '\t' + Name + '\t'
                + UserName + '\t' + Password + '\t' 
                + JobTitle + '\t' + BirthDate + '\t' 
                + HireDate + '\t' + Address;
        }
    }
}
