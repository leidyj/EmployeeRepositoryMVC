using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDT
{
    public class DTServiceResponse<T> where T : class
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public bool Response { get; set; }
    }
}
