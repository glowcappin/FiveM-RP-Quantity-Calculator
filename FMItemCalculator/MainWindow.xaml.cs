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

namespace FMItemCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            int totalAmnt = 0;

            if(boxOne.Text != "")
            {
                totalAmnt += Int32.Parse(boxOne.Text) * 500;
            }
            if (boxTwo.Text != "")
            {
                totalAmnt += Int32.Parse(boxTwo.Text) * 600;
            }
            if (boxThree.Text != "")
            {
                totalAmnt += Int32.Parse(boxThree.Text) * 2000;
            }
            if (boxFour.Text != "")
            {
                totalAmnt += Int32.Parse(boxFour.Text) * 400;
            }
            if (boxFive.Text != "")
            {
                totalAmnt += Int32.Parse(boxFive.Text) * 200;
            }
            if (boxSix.Text != "")
            {
                totalAmnt += Int32.Parse(boxSix.Text) * 50;
            }
            if (boxSeven.Text != "")
            {
                totalAmnt += Int32.Parse(boxSeven.Text) * 400;
            }

            clcAmnt.Text = totalAmnt.ToString();
        }
    }
}
