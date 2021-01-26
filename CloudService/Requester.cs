using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Security.Cryptography;

namespace CloudService
{
    public class Requester
    {
        public string token;
        HttpWebRequest request;
        string url = "https://webdav.yandex.ru/";
        public Requester(string authtoken)
        {
            token = authtoken;
        }
        public List<string> GetFiles()
        {
            request = WebRequest.CreateHttp(url);
            request.Method = "PROPFIND";
            request.Accept = "*/*";
            request.Headers["Depth"] = "1";
            request.Headers["Authorization"] = "OAuth " + token;
            request.ContentType = "text/xml; encoding='utf-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string dinfo = sr.ReadToEnd();
            return Xml(dinfo);
        }
        public void LoadFile(Stream fileStream)
        {
            //request = WebRequest.CreateHttp(url);
            //var sha = SHA256.Create;
            /*request.Method = "PUT";
            request.ContentLength = str.Length;
            request.Accept =
            request.ReadWriteTimeout = -1;
            request.Timeout = -1;
            request.Headers["Authorization"] = "OAuth " + token;
            request.Headers["Etag"] = "";
            request.Headers["Sha256"] = "";
            request.ServicePoint.Expect100Continue = true;
            request.ContentType = "application/binary";
            request.ContentLength = 1;*/


            /* вызывает ошибку конфликт 409
            request.Accept = 
            request.Headers["Depth"] = "1";
            request.Headers["Authorization"] = "OAuth " + token;
            request.Method = "PUT";
            request.AllowWriteStreamBuffering = false;
            request.SendChunked = true;
            request.BeginGetRequestStream(
                getRequestStreamResult =>
                {
                    var getRequestStreamRequest = (HttpWebRequest)getRequestStreamResult.AsyncState;
                    using (var requestStream = getRequestStreamRequest.EndGetRequestStream(getRequestStreamResult))
                    {
                        const int BUFFER_LENGTH = 4096;
                        var total = (ulong)fileStream.Length;
                        ulong current = 0;
                        var buffer = new byte[BUFFER_LENGTH];
                        var count = fileStream.Read(buffer, 0, BUFFER_LENGTH);
                        while (count > 0)
                        {
                            requestStream.Write(buffer, 0, count);
                            current += (ulong)count;
                            count = fileStream.Read(buffer, 0, BUFFER_LENGTH);
                        }

                        fileStream.Dispose();
                    }

                    getRequestStreamRequest.BeginGetResponse(
                        getResponseResult =>
                        {
                            var getResponseRequest = (HttpWebRequest)getResponseResult.AsyncState;
                            using (getResponseRequest.EndGetResponse(getResponseResult))
                            {
                            }
                        },
                        getRequestStreamRequest);
                },
                    request);*/

        }
        private List<string> Xml(string xml)
        {
            List<string> hrefs = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode response in xRoot)
            {
                foreach (XmlNode href in response.ChildNodes)
                {
                    if (href.Name == "d:href" && href.InnerText != "/")
                        hrefs.Add(href.InnerText.Substring(1));
                }
            }
            return hrefs;
        }
    }
}
