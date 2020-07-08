using EmployeesBM;
using EmployeesDT.Constants;
using EmployeesDT.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllEmployees()
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            return serializer.Serialize(ResultList);
        }

        public string GetEmployeeById(int Id)
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            return serializer.Serialize(ResultList);
        }
    }
}