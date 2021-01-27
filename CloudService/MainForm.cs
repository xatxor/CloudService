using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Disk.SDK;
using Disk.SDK.Provider;

namespace CloudService
{
    public partial class MainForm : Form
    {
        DiskSdkClient sdk;
        Requester req;
        IEnumerable<string> fileNames;
        Zipper zip;
        string archivepath;
        public MainForm()
        {
            InitializeComponent();
            zip = new Zipper(new AsyncProgress(UpdateProgress));
            req = new Requester(loginControl.token);
            sdk = new DiskSdkClient(loginControl.token);
            archiveNameTextbox.Text = "archive" + DateTime.Today.ToString("d").Replace(".", "") + ".zip";
            GetFilesFromDisk();
            ButtonsOff();
        }
        private void GetFilesFromDisk()
        {
            List<string> list = req.GetFiles();
            foreach (var str in list)
            {
                Label lab = new Label();
                lab.Width = filesPanel.Width-10;
                lab.Text = str;
                filesPanel.Controls.Add(lab);
            }
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            loadPanel.Controls.Clear();
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog1.FileNames;
                UpdateTabTitle();
                foreach (var str in fileNames)
                {
                    Label lab = new Label();
                    lab.Width = loadPanel.Width-10;
                    lab.Text = Path.GetFileName(str);
                    loadPanel.Controls.Add(lab);
                }
                zipButton.Enabled = true;
                sendButton.Enabled = false;
            }
        }
        private void UpdateTabTitle()
        {
            tabControl.TabPages[0].Text = "Выбранные файлы: " + fileNames.Count();
        }
        private void zipButton_Click(object sender, EventArgs e)
        {
            DeleteArchive();
            string path = Path.GetDirectoryName(fileNames.First());
            zip.Zip(path, archiveNameTextbox.Text, fileNames);
            archivepath = zip.archPath;
            fileNames = null;
            sendButton.Enabled = true;
            zipButton.Enabled = false;
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (archivepath != null)
            {
                var arhstream = new FileStream(archivepath, FileMode.Open);
                sdk.UploadFileAsync(Path.GetFileName(archivepath), arhstream, new AsyncProgress(this.UpdateProgress), this.SdkOnUploadCompleted);
            }
            else
                MessageBox.Show("Архивируйте файлы");
            zipButton.Enabled = false;
            sendButton.Enabled = false;
        }
        delegate void Del();
        private void UpdateProgress(ulong current, ulong total)
        {
            if ((int)total > progressBar.Maximum)
                progressBar.Invoke(new Del(() => progressBar.Maximum = (int)total));
            progressBar.Invoke(new Del(() => progressBar.Value = (int)current));
            progressBar.Invoke(new Del(() => progressBar.Maximum = (int)total));
        }
        private void UpdateProgress(ulong current)
        {
            progressBar.Invoke(new Del(() => progressBar.Value = (int)current));
        }
        private void SdkOnUploadCompleted(object sender, SdkEventArgs e)
        {
            MessageBox.Show("Архив отправлен!");
        }
        private void archiveNameTextbox_TextChanged(object sender, EventArgs e)
        {
            string name = archiveNameTextbox.Text;
            if (name.Length < 5 || name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1 || name.Substring(name.Length-4) != ".zip") 
            { 
                archiveNameTextbox.ForeColor = Color.Red;
                ButtonsOff();
            }
            else
            {
                archiveNameTextbox.ForeColor = Color.Black;
                ButtonsOn();
            }
        }
        private void ButtonsOff()
        {
            zipButton.Enabled = false;
            sendButton.Enabled = false;
        }
        private void ButtonsOn()
        {
            zipButton.Enabled = true;
            sendButton.Enabled = true;
        }
        private void DeleteArchive()
        {
            if (archivepath != null)
                File.Delete(archivepath);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteArchive();
        }
    }
}
