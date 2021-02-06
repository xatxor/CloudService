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
using Disk.SDK;

namespace CloudService
{
    public class Requester
    {
        public string token;
        DiskSdkClient sdk;
        public IEnumerable<DiskItemInfo> Files;
        public delegate void Dgt();
        public event Dgt InfoCompleted;
        public event Dgt DeleteCompleted;
        public Requester(string authtoken)
        {
            token = authtoken;
            sdk = new DiskSdkClient(authtoken);
        }
        public void GetList(string path = "/")
        {
            sdk.GetListCompleted += this.GetListCompleted;
            sdk.GetListAsync(path);
        }
        private void GetListCompleted(object sender, GenericSdkEventArgs<IEnumerable<DiskItemInfo>> e)
        {
            if (e.Error == null)
            {
                Files = e.Result;
                InfoCompleted?.Invoke();
            }
        }
        public void DeleteOldFiles(int days)
        {
            if (Files != null)
            {
                foreach (var file in Files)
                {
                    if ((DateTime.Now - file.LastModified).TotalDays > days)
                    {
                        sdk.RemoveAsync(file.OriginalFullPath);
                        sdk.TrashAsync(file.OriginalFullPath);
                    }
                }
                DeleteCompleted?.Invoke();
            }
        }
    }
}
