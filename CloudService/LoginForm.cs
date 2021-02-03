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
    public partial class LoginForm : Form
    {
        public string token { get; set; }
        private string client_id = "0a653308ad05418b87538c1775634e1f";
        string path;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            path = "https://oauth.yandex.ru/authorize?response_type=token&client_id=" + client_id;
            browser.Navigate(path);
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            label1.Visible = false;
            string url = browser.Url.ToString();
            if (url.Contains("https://oauth.yandex.ru/verification_code#access_token="))
            {
                int i = url.IndexOf('=');
                int j = url.IndexOf('&');
                token = url.Substring(i + 1, j - i - 1);
                this.Close();
            }
        }
    }
}
