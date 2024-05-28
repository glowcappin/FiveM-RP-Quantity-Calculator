using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class MainWindow : Window
    {
        // declare cache locations and other needed variables
        static string userAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string userCache = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GlowFiveM\\items";
        string[] userItems;

        public int totalSum = 0; // totalSum variable: a variable to calculate the total amount of the items. Default value of '0'.
        int originalAmnt = 85; // originalAmnt: A margin value for the second textbox. Default value of '85'.
        int txtAmnt = 1; // txtAmnt: The amount of aTextbox(s), the default is '1' because there is aalways one aTextBox by default.
        aTextBox[] userInputs = new aTextBox[5]; // userInputs: An array that holds all textboxes. Default value of '5'.

        #region Main Method 
        public MainWindow()
        {
            InitializeComponent();

            // check if the item cache actually exists to place textboxes
            if (File.Exists(userCache))
            {
                // find username for ui elements
                string userName = File.ReadAllText(userCache);
                userName = userName.Split('_')[0];

                userItems = File.ReadAllLines(userCache);
                boxOne.HintText = userItems[0].Split('$')[0]; // FMItemCalculator will ALWAYS have at least one box, this is outside of the addItemBoxes() function
                for (int a = 1; a < userItems.Length; a++) // i = 1 because boxOne is already there
                {
                   addItemBoxes(userItems[a].Substring(0, userItems[a].IndexOf("$")), null, userItems[a].Substring(userItems[a].LastIndexOf("$"))); // add textboxes for all items in cache
                }
                // change window title to have username
                this.Title = "FM Item Calculator - Logged in as " + userName;
            }
        }
        #endregion

        #region Reference Methods
        private void saveClipboard_Click(object sender, RoutedEventArgs e)
        {
            string clipboardText = string.Empty;

            if(boxOne.Text != "") // because boxOne is there by default, it is outside of the loop
            {
                clipboardText = boxOne.Text + " " + boxOne.HintText;
            }

            for(int i = 1; i < userItems.Length; i ++) // loop to get every item that exists
            {
                if (userInputs[i].Text != "")
                {
                    clipboardText += ", " + userInputs[i].Text + " " + userInputs[i].HintText;
                }
            }
            updateTotal();
            clipboardText += " $" + totalSum;
            Clipboard.SetText(clipboardText);

        }

        private void updateTotal(object sender, RoutedEventArgs e)
        {
            updateTotal();
        }

        #endregion

        #region Custom Methods
        public void updateTotal()
        {
            string absoluteCahce = userAppData + "\\GlowFiveM\\items";
            string[] userItems = File.ReadAllLines(absoluteCahce);
            if (boxOne.Text != "")
            {
                totalSum += Int32.Parse(boxOne.Text) * Int32.Parse(userItems[0].Substring(userItems[0].IndexOf("$") + 1));
            }
            for (int i = 1; i < userInputs.Length; i++)
            {
                if (userInputs[i].Text != "")
                {
                    totalSum += Int32.Parse(userInputs[i].Text) * Int32.Parse(userItems[i].Substring(userItems[i].IndexOf("$") + 1));
                }
            }
            clcAmnt.Text = totalSum.ToString();
        }
        public void addItemBoxes(string itemHint, string itemName, string itemPrice)
        {
            aTextBox txt = new aTextBox(); // create aTextBox from Amyst library
            mainGrid.Children.Add(txt); 
            txt.VerticalAlignment = VerticalAlignment.Top;
            txt.TextWrapping = TextWrapping.Wrap;

            txtAmnt += 1; // add one to txtAmnt variable to indicate another box has been added

            txt.Margin = new Thickness(boxOne.Margin.Left, originalAmnt, boxOne.Margin.Right, boxOne.Margin.Bottom); // set location of the textbox

            originalAmnt += 31; // add the margin value for the next textbox to be added

            // set height, width and hint
            txt.Height = 26;
            txt.Width = 331;

            if (itemHint != null) 
            {
                txt.HintText = itemHint;
            }
            else
            {
                txt.HintText = "Item " + txtAmnt;
            }

            if (itemName != null)
            {
                txt.Text = itemName;
            }

            Array.Resize<aTextBox>(ref userInputs, txtAmnt); // Resize userInputs array, as default value is '5'
            userInputs[txtAmnt - 1] = txt; 


            this.Height += 31; // change height of MainWindow to adjust for new boxes

            // chanage location of UI elements
            clcBtn.Margin = new Thickness(clcBtn.Margin.Left, clcBtn.Margin.Top + 31, clcBtn.Margin.Right, clcBtn.Margin.Bottom);
            saveClipboard.Margin = new Thickness(saveClipboard.Margin.Left, saveClipboard.Margin.Top + 31, saveClipboard.Margin.Right, saveClipboard.Margin.Bottom);
            clcAmnt.Margin = new Thickness(clcAmnt.Margin.Left, clcAmnt.Margin.Top + 31, clcAmnt.Margin.Right, clcAmnt.Margin.Bottom);
        }
        #endregion

        #region UI Elements
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
        #endregion
    }
}
