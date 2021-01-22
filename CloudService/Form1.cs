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

namespace CloudService
{
    public partial class Form1 : Form
    {
        IEnumerable<string> fileNames;
        Zipper zip = new Zipper();
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            fileNames = openFileDialog1.FileNames;
            selectedFilesLabel.Text = "Файлов выбрано: " + fileNames.Count();
            foreach (var str in fileNames)
                selectedFilesTextbox.Text += Path.GetFileName(str) + Environment.NewLine;
        }

        private void zipButton_Click(object sender, EventArgs e)
        {
            if (fileNames != null)
            {
                path = Path.GetDirectoryName(fileNames.First());
                zip.Add(path, fileNames);
            }
            else
                MessageBox.Show("Выбрано 0 файлов");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            
        }

        private void selectedFilesTextbox_Enter(object sender, EventArgs e)
        {
            selectedFilesTextbox.Enabled = false;
            selectedFilesTextbox.Enabled = true;
        }
    }
}
