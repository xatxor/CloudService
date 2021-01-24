using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;

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
