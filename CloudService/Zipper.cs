using Disk.SDK;
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
        IProgress Progress;
        public string archPath;
        public Zipper(IProgress progress) 
        {
            Progress = progress;
        }
        public async void Zip(string path, string archiveName, string password,IEnumerable<string> filenames)
        {
            archPath = path + "//" + archiveName;
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = password;
                foreach (var str in filenames)
                    zip.AddFile(str).FileName = Path.GetFileName(str);
                zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                zip.SaveProgress += SaveProgress;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                await Task.Run(() => zip.Save(archPath));
            }
        }
        public async void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_AfterWriteEntry)
                await Task.Run(() => Progress.UpdateProgress((ulong)(e.EntriesSaved * 100 / e.EntriesTotal), 100));
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                await Task.Run(() => Progress.UpdateProgress(100, 100));
                MessageBox.Show("Архивировано!");
            }
        }
    }
}
