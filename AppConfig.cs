using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOAapp1
{
    public class AppConfig
    {
     public string filePath { get; set; }
     public string webUrl { get; set; }
     public string folderPath { get; set; }

        public void Configuration()
        {
            filePath = ConfigurationManager.AppSettings["filePath"];
            webUrl = ConfigurationManager.AppSettings["webUrl"];
            folderPath = ConfigurationManager.AppSettings["folderPath"];

        }
    }
}
