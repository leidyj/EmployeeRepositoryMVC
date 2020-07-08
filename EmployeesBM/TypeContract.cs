using EmployeesDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBM
{
    abstract class TypeContract: DTEmployee
    {
        public virtual double CalculatedAnnualSalary(DTEmployee dTEmployee)
        {
            return new double();
        }
    }
}
