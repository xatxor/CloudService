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
        public string Zip(string path, string archiveName, IEnumerable<string> filenames)
        {
            string archivepath = path + "//" + archiveName;
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "xxx";
                foreach (var str in filenames)
                    zip.AddFile(str).FileName = Path.GetFileName(str);
                zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.Save(archivepath);
                MessageBox.Show("Архивировано!");
            }
            return archivepath;
        }
    }
}
