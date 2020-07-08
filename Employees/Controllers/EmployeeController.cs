using EmployeesBM;
using EmployeesDT.Constants;
using EmployeesDT.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employees.Controllers
{
    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetEmployees()
        {
            EmployeesDT.DTServiceResponse<List<EmployeesDT.DTEmployee>> ResultList = new EmployeesDT.DTServiceResponse<List<EmployeesDT.DTEmployee>>();
            try
            {

                ResultList = new EmployeeBM().GetAllEmployees();
            }
            catch (Exception ex)
            {
                new Log().Add(ex.Message);
                ResultList.Message = MessageConstants.ErrorMessage;
                ResultList.Response = false;
            }

            return Ok(ResultList);
        }

        public IHttpActionResult GetEmployee(int Id)
        {
            EmployeesDT.DTServiceResponse<List<EmployeesDT.DTEmployee>> ResultList = new EmployeesDT.DTServiceResponse<List<EmployeesDT.DTEmployee>>();
            try
            {

                ResultList = new EmployeeBM().GetEmployeeById(Id);
            }
            catch (Exception ex)
            {
                new Log().Add(ex.Message);
                ResultList.Message = MessageConstants.ErrorMessage;
                ResultList.Response = false;
            }

            return Ok(ResultList);
        }
    }
}
