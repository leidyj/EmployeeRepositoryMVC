using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBM
{
    class HourlySalary:TypeContract
    {
        public override double CalculatedAnnualSalary(EmployeesDT.DTEmployee dTEmployee)
        {
            double CalculatedSalary = 0;
            try
            {
                CalculatedSalary = 120 * dTEmployee.hourlySalary * 12;
            }
            catch (Exception ex)
            {
            }
            return CalculatedSalary;
        }
    }
}
