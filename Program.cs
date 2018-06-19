using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KOAapp1
{
    class Program
    {


        static void Main(string[] args)
        {
         
            AppConfig config = new AppConfig();
            config.Configuration();
           

            FileDownloadWebHtml KOA = new FileDownloadWebHtml();
            KOA.Download(config.webUrl, config.filePath);

            
            FileReaderImgUrl images = new FileReaderImgUrl();
            images.Reader(config.filePath, config.folderPath);

            Console.ReadLine();

        }
       
    }
}
