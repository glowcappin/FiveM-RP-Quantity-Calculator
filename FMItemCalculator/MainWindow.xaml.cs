using System;
using System.Collections.Generic;
using System.IO;
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

namespace FMItemCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userappData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        
        public MainWindow()
        {
            InitializeComponent();
            string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // get LocalAppData
            string absoluteCahce = userappData + "\\GlowFiveM"; ; // get items path
            if (Directory.Exists(absoluteCahce))
            {
                string[] userItems = File.ReadAllLines(absoluteCahce + "\\items");
                boxOne.HintText = userItems[0].Split('$')[0];
                boxTwo.HintText = userItems[1].Split('$')[0];
                boxThree.HintText = userItems[2].Split('$')[0];
                boxFour.HintText = userItems[3].Split('$')[0];
                boxFive.HintText = userItems[4].Split('$')[0];
                boxSix.HintText = userItems[5].Split('$')[0];
                boxSeven.HintText = userItems[6].Split('$')[0];
                boxEight.HintText = userItems[7].Split('$')[0];
                boxNine.HintText = userItems[8].Split('$')[0];
                boxTen.HintText = userItems[9].Split('$')[0];
            }
        }

        private void updateTotal()
        {

        }

        private void settingsIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            settingsWindow stn = new settingsWindow();
            stn.Show();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState.Equals(WindowState.Minimized);
        }

        private void saveClipboard_Click(object sender, RoutedEventArgs e)
        {
            string absoluteCahce = userappData + "\\GlowFiveM"; ; // get items path
            string[] userItems = File.ReadAllLines(absoluteCahce + "\\items");
            Clipboard.SetText(boxOne.Text + " " + boxOne.HintText + " $" + userItems[0].Substring(userItems[0].IndexOf("$") + 1) + "\n" +
                              boxTwo.Text + " " + boxTwo.HintText + " $" + userItems[1].Substring(userItems[1].IndexOf("$") + 1) + "\n" +
                              boxThree.Text + " " + boxThree.HintText + " $" + userItems[2].Substring(userItems[2].IndexOf("$") + 1) + "\n" +
                              boxFour.Text + " " + boxFour.HintText + " $" + userItems[3].Substring(userItems[3].IndexOf("$") + 1) + "\n" +
                              boxFive.Text + " " + boxFive.HintText + " $" + userItems[4].Substring(userItems[4].IndexOf("$") + 1) + "\n" +
                              boxSix.Text + " " + boxSix.HintText + " $" + userItems[5].Substring(userItems[5].IndexOf("$") + 1) + "\n" +
                              boxSeven.Text + " " + boxSeven.HintText + " $" + userItems[6].Substring(userItems[6].IndexOf("$") + 1) + "\n");
        }

        private void updateTotal(object sender, RoutedEventArgs e)
        {
            int totalAmnt = 0;
            string absoluteCahce = userappData + "\\GlowFiveM"; ; // get items path
            string[] userItems = File.ReadAllLines(absoluteCahce + "\\items");
            if (boxOne.Text != "")
            {
                totalAmnt += Int32.Parse(boxOne.Text) * Int32.Parse(userItems[0].Substring(userItems[0].IndexOf("$") + 1));
            }
            if (boxTwo.Text != "")
            {
                totalAmnt += Int32.Parse(boxTwo.Text) * Int32.Parse(userItems[1].Substring(userItems[1].IndexOf("$") + 1));
            }
            if (boxThree.Text != "")
            {
                totalAmnt += Int32.Parse(boxThree.Text) * Int32.Parse(userItems[2].Substring(userItems[2].IndexOf("$") + 1));
            }
            if (boxFour.Text != "")
            {
                totalAmnt += Int32.Parse(boxFour.Text) * Int32.Parse(userItems[3].Substring(userItems[3].IndexOf("$") + 1));
            }
            if (boxFive.Text != "")
            {
                totalAmnt += Int32.Parse(boxFive.Text) * Int32.Parse(userItems[4].Substring(userItems[4].IndexOf("$") + 1));
            }
            if (boxSix.Text != "")
            {
                totalAmnt += Int32.Parse(boxSix.Text) * Int32.Parse(userItems[5].Substring(userItems[5].IndexOf("$") + 1));
            }
            if (boxSeven.Text != "")
            {
                totalAmnt += Int32.Parse(boxSeven.Text) * Int32.Parse(userItems[6].Substring(userItems[6].IndexOf("$") + 1));
            }
            if (boxEight.Text != "")
            {
                totalAmnt += Int32.Parse(boxEight.Text) * Int32.Parse(userItems[7].Substring(userItems[7].IndexOf("$") + 1));
            }
            if (boxNine.Text != "")
            {
                totalAmnt += Int32.Parse(boxNine.Text) * Int32.Parse(userItems[8].Substring(userItems[8].IndexOf("$") + 1));
            }
            if (boxTen.Text != "")
            {
                totalAmnt += Int32.Parse(boxTen.Text) * Int32.Parse(userItems[9].Substring(userItems[9].IndexOf("$") + 1));
            }

            clcAmnt.Text = totalAmnt.ToString();
        }
    }
}
