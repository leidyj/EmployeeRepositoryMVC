using EmployeesDT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDM
{
    public class EmployeeApi
    {
        public DTServiceResponse<List<DTEmployee>> GetAllEmployees()
        {
            DTServiceResponse<List<DTEmployee>> _ApiResponse = new DTServiceResponse<List<DTEmployee>>();
            string resultado = new Client().GetAllEmployees();
            List<DTEmployee> rpta = JsonConvert.DeserializeObject<List<DTEmployee>>(resultado);
            if (rpta != null)
            {
                _ApiResponse.Result = rpta;
                _ApiResponse.Response = true;
            }
            return _ApiResponse;
        }
    }
}
