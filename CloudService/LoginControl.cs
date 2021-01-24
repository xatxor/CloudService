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
    public partial class LoginControl : UserControl
    {
        public string token { get; set; }
        private string client_id = "0a653308ad05418b87538c1775634e1f";
        string path;
        public LoginControl()
        {
            //"https://oauth.yandex.ru/verification_code#access_token=AgAAAABPGUwfAAbUENAGNkexA0nfhkx4wvmr51s&token_type=bearer&expires_in=31535931"
            InitializeComponent();
            path = "https://oauth.yandex.ru/authorize?response_type=token&client_id=" + client_id;
            browser.Navigate(path);
        }
        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = browser.Url.ToString();
            if (url.Contains("https://oauth.yandex.ru/verification_code#access_token="))
            {
                int i = url.IndexOf('=');
                int j = url.IndexOf('&');
                token = url.Substring(i + 1, j - i - 1);
                this.Enabled = false;
                this.Visible = false;
            }
        }
    }
}
