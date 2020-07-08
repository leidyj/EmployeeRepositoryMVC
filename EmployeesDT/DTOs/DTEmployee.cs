using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDT
{
    public class DTEmployee
    {
        public int id { set; get; }
        public string name { set; get; }
        public string contractTypeName { set; get; }
        public int roleId { set; get; }
        public string roleName { set; get; }
        public string roleDescription { set; get; }
        public double hourlySalary { set; get; }
        public double monthlySalary { set; get; }
        public double annualSalary{ set; get; }
    }
}
