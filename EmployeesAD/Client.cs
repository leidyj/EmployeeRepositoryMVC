using EmployeesDT.Constants;
using Spring.Http;
using Spring.Http.Client;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDM
{
    public class Client
    {
        public string GetAllEmployees()
        {
            Spring.Http.HttpHeaders headers = new Spring.Http.HttpHeaders();
            HttpEntity entity = new HttpEntity();
            RestTemplate template = new RestTemplate();
            entity = new HttpEntity(headers);
            HttpEntity requestEntity = new HttpEntity();
            template = new RestTemplate(ConfigurationManager.AppSettings.Get("URLApi"));
            template = PrepararTemplate(template);
            var respuesta = template.Exchange<string>(string.Format(EmployeeApiConstants.UrlGetAllEmployees, ConfigurationManager.AppSettings.Get("URLApi")), HttpMethod.GET, requestEntity);
            return respuesta.Body;
        }

        private RestTemplate PrepararTemplate(RestTemplate template)
        {
            template.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
            WebClientHttpRequestFactory requestFactory = new WebClientHttpRequestFactory();
            requestFactory.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Timeout"));
            template.RequestFactory = requestFactory;
            return template;
        }
    }
}
