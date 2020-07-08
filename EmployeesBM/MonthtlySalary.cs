using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBM
{
    class MonthtlySalary: TypeContract
    {
        public override double CalculatedAnnualSalary(EmployeesDT.DTEmployee dTEmployee)
        {
            double CalculatedSalary = 0;
            try
            {
                CalculatedSalary = dTEmployee.monthlySalary * 12;
            }
            catch(Exception ex)
            { 
            }
            return CalculatedSalary;
        }
    }
}
