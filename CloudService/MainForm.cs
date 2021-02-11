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
        bool isArchNameCorrect = true;
        bool isDiskPathCorrect = true;
        LoginForm logform;
        public MainForm()
        {
            InitializeComponent();
            logform = new LoginForm();
            logform.ShowDialog();
            zip = new Zipper(new AsyncProgress(UpdateProgress));
            req = new Requester(logform.token);
            sdk = new DiskSdkClient(logform.token);
            archivePathOnDiskTextbox.Text = "/";
            archiveNameTextbox.Text = "archive";
            ChangeButtonsStatus();
            GetFilesFromDisk();
            req.InfoCompleted += InfoCompleted;
            req.Error += Error;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                try
                {

                    loadinglabel.Visible = true;
                    CommandLineArgsHandler handler = new CommandLineArgsHandler(logform.token, args[1], args[2], Convert.ToInt32(args[3]), args[4], args[5]);
                    handler.Error += Error;
                    handler.Completed += CommandHandlerCompleted;
                    handler.StartAndZip();
                }catch
                {
                    ShowHelp(args);
                    Application.Exit();
                }
            }
        }

        private static void ShowHelp(string[] args)
        {
            MessageBox.Show($"Синтаксис командной строки:\n" +
                $"{args[0]}\nИМЯ_ПАПКИ_В_ОБЛАКЕ\nИМЯ_АРХИВА\nСКОЛЬКО_ДНЕЙ_ХРАНИТЬ_АРХИВЫ\nПАРОЛЬ\nЛОКАЛЬНАЯ_ПАПКА_БЭКАПА\n" +
                $"\n" +
                $"Папка в облаке с именем ИМЯ_ПАПКИ_В_ОБЛАКЕ должна быть создана заранее.");
        }

        delegate void Del();
        private void Error()
        {
            loadinglabel.Visible = false;
            MessageBox.Show("При обращению к диску возникла ошибка, проверьте все введенные данные");
        }
        private void CommandHandlerCompleted()
        {
            loadinglabel.Invoke(new Del(() => loadinglabel.Visible = false));
            Application.Exit();
        }
        private void InfoCompleted()
        {
            IEnumerable<DiskItemInfo> list = req.Files;
            foreach (var file in list)
            {
                Label lab = new Label();
                lab.Width = filesPanel.Width - 10;
                lab.Text = file.DisplayName;
                filesPanel.Controls.Add(lab);
            }
        }
        private void GetFilesFromDisk()
        {
            try
            {
                req.GetList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Возникла ошибка: " + e.Message);
            }
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            ChangeButtonsStatus();
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
                ChangeButtonsStatus();
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
            string pass = passwordTextbox.Text;
            if (pass == "" || pass == " ")
                pass = null;
            string archiveFullName = archiveNameTextbox.Text + "_" +
                DateTime.Today.ToString("d").Replace(".", "") + ".zip";
            zip.Zip(path, archiveFullName, pass,fileNames);
            archivepath = zip.archPath;
            fileNames = null;
            ChangeButtonsStatus();
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (archivepath != null)
            {
                var arhstream = new FileStream(archivepath, FileMode.Open);
                string archivePathOnDisk = archivePathOnDiskTextbox.Text + Path.GetFileName(archivepath);
                sdk.UploadFileAsync(archivePathOnDisk, arhstream, new AsyncProgress(this.UpdateProgress), this.SdkOnUploadCompleted);
            }
            else
                MessageBox.Show("Архивируйте файлы");
            ChangeButtonsStatus();
        }
        private void UpdateProgress(ulong current, ulong total)
        {
            if ((int)total > progressBar.Maximum)
                progressBar.Invoke(new Del(() => progressBar.Maximum = (int)total));
            progressBar.Invoke(new Del(() => progressBar.Value = (int)current));
            progressBar.Invoke(new Del(() => progressBar.Maximum = (int)total));
        }
        private void SdkOnUploadCompleted(object sender, SdkEventArgs e)
        {
            if (e.Error == null)
            {
                DeleteArchive();
                MessageBox.Show("Архив отправлен!");
            }
            else
                MessageBox.Show("Возникла ошибка, может указанного каталога не существует?");
        }
        private void archiveNameTextbox_TextChanged(object sender, EventArgs e)
        {
            string name = archiveNameTextbox.Text;
            if (name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) 
            { 
                archiveNameTextbox.ForeColor = Color.Red;
                isArchNameCorrect = false;
            }
            else
            {
                archiveNameTextbox.ForeColor = Color.Black;
                isArchNameCorrect = true;
            }
            ChangeButtonsStatus();
        }
        private void archivePathOnDiskTextbox_TextChanged(object sender, EventArgs e)
        {
            string path = archivePathOnDiskTextbox.Text;
            if (!path.EndsWith("/"))
            {
                archivePathOnDiskTextbox.ForeColor = Color.Red;
                isDiskPathCorrect = false;
            }
            else
            {
                archivePathOnDiskTextbox.ForeColor = Color.Black;
                isDiskPathCorrect = true;
            }
            ChangeButtonsStatus();
        }
        private void ChangeButtonsStatus()
        {
            if (isArchNameCorrect && fileNames != null)
                zipButton.Enabled = true;
            else
                zipButton.Enabled = false;
            if (isDiskPathCorrect && archivepath != null)
                sendButton.Enabled = true;
            else
                sendButton.Enabled = false;
        }
        private void DeleteArchive()
        {
            if (archivepath != null)
            {
                File.Delete(archivepath);
                archivepath = null;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteArchive();
        }
    }
}
