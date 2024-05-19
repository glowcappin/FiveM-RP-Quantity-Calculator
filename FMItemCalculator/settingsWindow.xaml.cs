using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for settingsWindow.xaml
    /// </summary>
    public partial class settingsWindow : Window
    {

        public string userappData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public settingsWindow()
        {
            InitializeComponent();
            string absoluteCahce = userappData + "\\GlowFiveM"; ; // get items path
            getUserProperties(absoluteCahce, boxOne, boxTwo, boxThree, boxFour, boxFive, boxSix, 
                boxSeven, boxEight, boxNine, boxTen, onePrice, twoPrice, threePrice, fourPrice, 
                fivePrice, sixPrice, sevenPrice, eightPrice, ninePrice, tenPrice);
        }

        public void getUserProperties(String cachePth, aTextBox boxOne, aTextBox boxTwo, aTextBox boxThree, aTextBox boxFour, aTextBox boxFive, aTextBox boxSix, aTextBox boxSeven, aTextBox boxEight, aTextBox boxNine, aTextBox boxTen, aTextBox onePrice, aTextBox twoPrice, aTextBox threePrice, aTextBox fourPrice, aTextBox fivePrice, aTextBox sixPrice, aTextBox sevenPrice, aTextBox eightPrice, aTextBox ninePrice, aTextBox tenPrice)
        {
            string[] userItems = File.ReadAllLines(cachePth + "\\items");
            boxOne.Text = userItems[0].Split('$')[0];   
            boxTwo.Text = userItems[1].Split('$')[0];
            boxThree.Text = userItems[2].Split('$')[0];
            boxFour.Text = userItems[3].Split('$')[0];
            boxFive.Text = userItems[4].Split('$')[0];
            boxSix.Text = userItems[5].Split('$')[0];
            boxSeven.Text = userItems[6].Split('$')[0];
            boxEight.Text = userItems[7].Split('$')[0];
            boxNine.Text = userItems[8].Split('$')[0];
            boxTen.Text = userItems[9].Split('$')[0];
            onePrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            twoPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            threePrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            fourPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            fivePrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            sixPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            sevenPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            eightPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            ninePrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);
            tenPrice.Text = userItems[0].Substring(userItems[0].IndexOf("$") + 1);

        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            
            string[] userItemsSave = { boxOne.Text, boxTwo.Text, boxThree.Text, boxFour.Text, boxFive.Text, boxSix.Text, boxSeven.Text, boxEight.Text, boxNine.Text, boxTen.Text};
            string[] userPriceSave = { onePrice.Text, twoPrice.Text, threePrice.Text, fourPrice.Text, fivePrice.Text, sixPrice.Text, sevenPrice.Text, eightPrice.Text, ninePrice.Text, tenPrice.Text };
            string absoluteCahce = userappData + "\\GlowFiveM"; ; // get items path
            if (!Directory.Exists(absoluteCahce))
            {
                Directory.CreateDirectory(absoluteCahce);
            }
            File.Delete(absoluteCahce + "\\itemsss");
            using (StreamWriter writetext = new StreamWriter(absoluteCahce + "\\items", true))
{
                for (int i = 0; i < userItemsSave.Length; i++)
                {
                    writetext.WriteLine(userItemsSave[i] + " $" + userPriceSave[i]);
                }
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
