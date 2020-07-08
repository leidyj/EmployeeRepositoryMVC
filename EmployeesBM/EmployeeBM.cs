using EmployeesDM;
using EmployeesDT;
using EmployeesDT.Constants;
using EmployeesDT.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesBM
{
    public class EmployeeBM
    {
       public DTServiceResponse<List<DTEmployee>> GetAllEmployees()
       {
            DTServiceResponse<List<DTEmployee>> response = new DTServiceResponse<List<DTEmployee>>();

            try
            {
                response = new EmployeeApi().GetAllEmployees();
                if (response.Result != null)
                {
                    foreach (var item in response.Result)
                    {
                        item.annualSalary = AnnualSalary(item).annualSalary;
                    }
                    response.Response = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = MessageConstants.ErrorMessage;
                response.Response = false;
            }
            return response;
       }

        public DTServiceResponse<List<DTEmployee>> GetEmployeeById(int Id)
        {

            DTServiceResponse<List<DTEmployee>> _employeeApi = new DTServiceResponse<List<DTEmployee>>();
            DTEmployee employee = new DTEmployee();

            try
            {
                employee = new EmployeeApi().GetAllEmployees().Result.FirstOrDefault(x => x.id == Id);
                List<DTEmployee> List = new List<DTEmployee>();

                if (employee != null)
                {
                    employee.annualSalary = AnnualSalary(employee).annualSalary;

                    List.Add(employee);
                    _employeeApi.Result = List;
                    _employeeApi.Response = true;
                }
                new Log().Add("Esto es una prueba");
            }
            catch (Exception ex)
            {
                _employeeApi.Message = MessageConstants.ErrorMessage;
                _employeeApi.Response = false;
            }
            return _employeeApi;
        }

        private DTEmployee AnnualSalary(DTEmployee dTEmployee) 
        {
            if (dTEmployee.contractTypeName == EmployeeApiConstants.TypeContractH)
            {
                dTEmployee.annualSalary = new HourlySalary().CalculatedAnnualSalary(dTEmployee);
            }
            else
            {
                dTEmployee.annualSalary = new MonthtlySalary().CalculatedAnnualSalary(dTEmployee);
            }
            return dTEmployee;
        }
    }
}
