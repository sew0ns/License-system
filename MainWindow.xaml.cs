using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;
using System.Configuration;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using LicenseXQO;

namespace LicenseXQO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string server_address = ConfigurationManager.AppSettings["server_address"];
        string license_path = ConfigurationManager.AppSettings["license_path"];
        LicenseClass hwid_class = new LicenseClass();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    string url = license_path;
                    using (var client_login = new WebClient())
                    {
                        client_login.Headers["User-Agent"] = "Mozilla/5.0";
                        var pars = new NameValueCollection();
                        pars.Add("action", "login");
                        pars.Add("username", txtUsername.Text);
                        pars.Add("password", txtPassword.Text);
                        pars.Add("hwid", hwid_class.HWID());
                        var response = client_login.UploadValues(url, pars);
                        string token = System.Text.Encoding.UTF8.GetString(response);
                        this.Hide();
                        new MenuWPF(txtUsername.Text, token).Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Неизвестная ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void BtnDebug_Click(object sender, RoutedEventArgs e)
        {
            DebugWPF win_deb = new DebugWPF();
            win_deb.ShowDialog();
        }
    }
}
