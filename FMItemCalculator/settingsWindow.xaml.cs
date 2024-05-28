using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            string absoluteCahce = userappData + "\\GlowFiveM\\items";

            if (File.Exists(absoluteCahce)) // check if file exists, then place corresponding items
            {
                string[] userItems = File.ReadAllLines(absoluteCahce);
                boxOne.Text = userItems[0].Split('$')[0]; // FMItemCalculator will ALWAYS have at least one box, this is outside of the addItemBoxes() function
                onePrice.Text = userItems[0].Substring(userItems[0].LastIndexOf("$"));
                for (int a = 1; a < userItems.Length; a++) // i = 1 because boxOne is already there
                {
                    addItemBoxes(null, userItems[a].Substring(0, userItems[a].IndexOf("$")), userItems[a].Substring(userItems[a].LastIndexOf("$"))); // add textboxes for all items in cache
                }
            }

        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            string absoluteCahce = userappData + "\\GlowFiveM\\items";
            if(File.Exists(absoluteCahce))
            {
                File.Delete(absoluteCahce);
            }
            File.AppendAllText(absoluteCahce, boxOne.Text + " $" + onePrice + Environment.NewLine);
            for (int i = 1; i < userInputs.Length; i++)
            {
                File.AppendAllText(absoluteCahce, userInputs[i].Text + " $" + userInputsPrc[i].Text + Environment.NewLine);
            }
            MessageBox.Show("The program will reset now.");
            reloadFMCalc();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBox_Click(object sender, RoutedEventArgs e)
        {
            addItemBoxes(null, null, null);
        }

        int originalAmnt = 43; // margin value for the second textbox
        int txtAmnt = 1; // amount of textboxes
        int originalAmntPrc = 43; // margin value for the second textbox
        int prcAmnt = 1; // amount of textboxes
        aTextBox[] userInputs = new aTextBox[5];
        aTextBox[] userInputsPrc = new aTextBox[5];
        public void addItemBoxes(string itemHint, string itemName, string itemPrice)
        {

            aTextBox txt = new aTextBox(); // create aTextBox from Amyst library
            settingsGrid.Children.Add(txt); // add it to the grid
            txt.VerticalAlignment = VerticalAlignment.Top;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.TextWrapping = TextWrapping.Wrap; 
            txtAmnt += 1;

            txt.Margin = new Thickness(boxOne.Margin.Left, originalAmnt, boxOne.Margin.Right, boxOne.Margin.Bottom); // set location of the textbox

            originalAmnt += 32; // add the margin value for the next textbox to be added

            // set height, width and hint
            txt.Height = 26;
            txt.Width = 283;

            if(itemHint != null)
            {
                txt.HintText = itemHint;
            }
            else
            {
                txt.HintText = "Item " + txtAmnt;
            }
            if(itemName != null)
            {
                txt.Text = itemName;
            }

            Array.Resize<aTextBox>(ref userInputs, txtAmnt); // resize array as default is 5
            userInputs[txtAmnt - 1] = txt;

            if(itemPrice != null)
            {
                addPriceBoxes(itemPrice);
            }
            else
            {
                addPriceBoxes(null);
            }
            
            this.Height += 33;
            saveConfig.Margin = new Thickness(saveConfig.Margin.Left, saveConfig.Margin.Top + 33, saveConfig.Margin.Right, saveConfig.Margin.Bottom);
            addBox.Margin = new Thickness(addBox.Margin.Left, addBox.Margin.Top + 33, addBox.Margin.Right, addBox.Margin.Left);
            eraseButton.Margin = new Thickness(eraseButton.Margin.Left, eraseButton.Margin.Top + 33, eraseButton.Margin.Right, eraseButton.Margin.Left);
        }

        public void addPriceBoxes(string itemPrice)
        {
            aTextBox prc = new aTextBox(); // create aTextBox from Amyst library
            settingsGrid.Children.Add(prc); // add it to the grid
            prc.VerticalAlignment = VerticalAlignment.Top;
            prc.HorizontalAlignment = HorizontalAlignment.Left;
            prc.TextWrapping = TextWrapping.Wrap;
            prcAmnt += 1;
            
            prc.Margin = new Thickness(onePrice.Margin.Left, originalAmntPrc, onePrice.Margin.Right, onePrice.Margin.Bottom); // set location of the textbox
            originalAmntPrc += 32;

            // set height, width and hint
            prc.Height = 26;
            prc.Width = 45;

            if(itemPrice != null)
            {
                prc.Text = itemPrice;
            }

            Array.Resize<aTextBox>(ref userInputsPrc, txtAmnt); // resize array as default is 5
            userInputsPrc[txtAmnt - 1] = prc;
            prc.HintText = "$";
        }

        int eraseCount;
        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            if (eraseCount != 1)
            {
                MessageBox.Show("If you're sure you want to reset your config, press the button once more.");
                eraseCount = 1;
            }
            else
            {
                File.Delete(userappData + "\\GlowFiveM\\items");
                reloadFMCalc();
            }
        }

        public void reloadFMCalc()
        {
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }
    }
}
