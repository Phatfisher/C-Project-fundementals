using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;

namespace KOAapp1
{
    class FileReaderImgUrl
    {

        private string filePath { get; set; }
        private string folderPath { get; set; }

        public void Reader(string filePath, string folderPath)
        {
            try
            {
                HtmlDocument htmldoc = new HtmlDocument();
                htmldoc.Load(filePath);
                var htmlnodecoll = htmldoc.DocumentNode.SelectNodes("//img[@src]");

                List<string> imageUrl = new List<string>();
                string baseUrl = "http://KOA.com";

                foreach (HtmlNode node in htmlnodecoll)
                {
                    if (node != null)
                    {
                        var src = node.Attributes["src"].Value;
                        imageUrl.Add(baseUrl + src);
                    }
                    else
                    {
                        Console.WriteLine("Node not Found. FileReaderImgUrl Line 31.");
                    }
                }

                List<string> listNodupes = imageUrl.Distinct().ToList();

                FileDownloadWebHtml images = new FileDownloadWebHtml();
                foreach (string x in listNodupes)
                {
                    if (string.IsNullOrWhiteSpace(x))
                    {
                        Console.WriteLine("string values in List not found. FileReaderImgUrl line 47.");
                    }
                    else
                    {
                        images.Download(x, folderPath + Path.GetFileName(x));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
