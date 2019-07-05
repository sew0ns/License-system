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
using System.Windows.Shapes;
using System.Configuration;
using System.Net;
using LicenseXQO;

namespace LicenseXQO
{
    /// <summary>
    /// Логика взаимодействия для DebugWPF.xaml
    /// </summary>
    public partial class DebugWPF : Window
    {
        string server_address = ConfigurationManager.AppSettings["server_address"];
        string license_path = ConfigurationManager.AppSettings["license_path"];
        public DebugWPF()
        {
            InitializeComponent();
            bool status_address = testSite(server_address);
            LicenseClass hwid_class = new LicenseClass();
            labelServerAddr.Content = labelServerAddr.Content + server_address;
            labelLicensePath.Content = labelLicensePath.Content + license_path;
            if (status_address = true)
            {
                labelConnectStatus.Content = labelConnectStatus.Content + "ON";
            }
            else
            {
                labelConnectStatus.Content = labelConnectStatus.Content + "OFF";
            }
            labelHWID.Content = labelHWID.Content + hwid_class.HWID();
            //Clipboard.SetText(hwid_class.HWID());
        }

        public bool testSite(string url)
        {

            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
