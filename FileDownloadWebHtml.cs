using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KOAapp1
{
    public class FileDownloadWebHtml
    {
        private string webUrl { get; set; }
        private string filePath { get; set; }

        public void Download(string webUrl, string filePath)
        {
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webUrl);
                request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";

                WebResponse response = request.GetResponse();
                using (Stream inputStream = response.GetResponseStream())
                {
                    using (Stream outputStream = File.OpenWrite(filePath))  
                    {
                        byte[] buffer = new byte[4096];
                        int byteRead;
                        do
                        {
                            byteRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, byteRead);
                        }
                        while (byteRead != 0);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
           
        }      
    }
    
}
