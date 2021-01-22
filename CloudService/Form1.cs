using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudService
{
    public partial class Form1 : Form
    {
        Zipper zip = new Zipper();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.ShowDialog();
            IEnumerable<string> fileNames = openFileDialog1.FileNames;
            zip.Add(fileNames);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
