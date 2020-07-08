using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using EmployeesDT.Constants;

namespace EmployeesDT.Error
{
    public class Log
    {
        private string Path = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["LogPath"]);


        public void Add(string sLog)
        {
            CreateDirectory();
            string nameFile = GetNameFile();
            string Text = string.Empty;

            Text += DateTime.Now + EmployeeApiConstants.SeparatorLogName + sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Path + EmployeeApiConstants.PathSeparator + nameFile, true);
            sw.Write(Text);
            sw.Close();
        }

        private string GetNameFile()
        {
            string name = string.Empty;
            name = DateTime.Now.Day.ToString() + EmployeeApiConstants.SeparatorLogName + DateTime.Now.Month.ToString() + EmployeeApiConstants.SeparatorLogName + DateTime.Now.Year.ToString()+EmployeeApiConstants.ExtensionLog;
            return name;
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
