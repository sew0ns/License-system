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

namespace LicenseXQO
{
    /// <summary>
    /// Логика взаимодействия для MenuWPF.xaml
    /// </summary>
    public partial class MenuWPF : Window
    {
        private string username;
        private string token;
        public MenuWPF(string username, string token)
        {
            InitializeComponent();
            this.username = username;
            this.token = token;
            txtHello.Content = txtHello.Content + username + "!";
        }
    }
}
