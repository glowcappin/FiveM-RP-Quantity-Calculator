using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
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

namespace FMItemCalculator
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string userappData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string userLogin;
        public LoginWindow()
        {
            InitializeComponent();
            string absoluteCahce = userappData + "\\GlowFiveM\\logins";  // get items path
            if (File.Exists(absoluteCahce))
            {
                WebClient webClient = new WebClient();
                bool loginFlag = true;
                if (loginFlag == true)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }
            this.Width = 296;
            this.Height = 110;
        }

        private void getLogin_Click(object sender, RoutedEventArgs e)
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string HWID = "";
            foreach (ManagementObject mo in mbsList)
            {
                HWID = mo["ProcessorId"].ToString();
                break;
            }
            if (loginBox.Equals("") || loginBox.Equals("Login"))
            {
                MessageBox.Show("Enter a name in the login to register!");
            }
            else
            {
                MessageBox.Show("Copied to clipboard: " + loginBox.Text + "_" + HWID);
                Clipboard.SetText(loginBox.Text + "_" + HWID);
            }
            
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
            ManagementObjectCollection mbsList = mbs.Get();
            string HWID = "";
            foreach (ManagementObject mo in mbsList)
            {
                HWID = mo["ProcessorId"].ToString();
                break;
            }
            WebClient webClient = new WebClient();
            bool loginFlag = true;
            if(loginFlag == true)
            {
                string absoluteCahce = userappData + "\\GlowFiveM\\logins";  // get items path
                File.WriteAllText(absoluteCahce, loginBox.Text + "_" + HWID);
                MessageBox.Show("Logged in as " + loginBox.Text);
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed! You are not registered in the server. Contact Glow");
            }
        }

        private void loginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            loginBox.Text = "";
        }
    }
}
