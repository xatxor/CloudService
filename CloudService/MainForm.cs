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

namespace CloudService
{
    public partial class MainForm : Form
    {
        IEnumerable<string> fileNames;
        Zipper zip = new Zipper();
        string path;
        public MainForm()
        {
            InitializeComponent();
            archiveNameTextbox.Text = "archive" + DateTime.Today.ToString("d").Replace(".", "") + ".zip";
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            ButtonsOff();
            loadPanel.Controls.Clear();
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog1.FileNames;
                tabControl.TabPages[0].Text = "Выбранные файлы: " + fileNames.Count();
                foreach (var str in fileNames)
                {
                    Label lab = new Label();
                    lab.Width = 2*loadPanel.Width;
                    lab.Text = Path.GetFileName(str);
                    loadPanel.Controls.Add(lab);
                }
                ButtonsOn();
            }
        }

        private void zipButton_Click(object sender, EventArgs e)
        {
            path = Path.GetDirectoryName(fileNames.First());
            zip.Add(path, archiveNameTextbox.Text, fileNames);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            
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
    }
}
