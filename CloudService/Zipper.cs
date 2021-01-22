using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudService
{
    public class Zipper
    {
        public void Add(IEnumerable<string> filenames)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "xxx";
                string path = Path.GetDirectoryName(filenames.First());
                foreach (var str in filenames)
                    zip.AddFile(str).FileName = Path.GetFileName(str);
                zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.Save(path + "//archive.zip");
                MessageBox.Show("File Zipped!");
            }
        }
    }
}
