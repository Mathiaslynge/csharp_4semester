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

namespace Opgave6
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
        

        private void radioBtn1_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = radioBtn1.Name + " Checked ";
        }

        private void radioBtn2_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = radioBtn2.Name + " Checked ";
        }

        private void radioBtn3_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = radioBtn3.Name + " Checked ";
        }

        private void radioBtn4_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = radioBtn4.Name + " Checked ";
        }

        private void chb1_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content += " | " + chb1.Name + " Checked";
        }

        private void chb2_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content += " | " + chb2.Name + " Checked";
        }

        private void chb3_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content += " | " + chb3.Name + " Checked";
        }

        private void chb4_Checked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content += " | " + chb4.Name + " Checked";
        }

        private void chb1_Unchecked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "";
            validate(sender, e);
        }



        private void validate(object sender, RoutedEventArgs e)
        {
            if (radioBtn1.IsChecked == true)
            {
                this.radioBtn1_Checked(sender, e);
            }
            if (radioBtn2.IsChecked == true)
            {
                this.radioBtn2_Checked(sender, e);
            }
            if (radioBtn3.IsChecked == true)
            {
                this.radioBtn3_Checked(sender, e);
            }
            if (radioBtn4.IsChecked == true)
            {
                this.radioBtn4_Checked(sender, e);
            }
            if (chb1.IsChecked == true)
            {
                this.chb1_Checked(sender, e);
            }
            if (chb2.IsChecked == true)
            {
                this.chb2_Checked(sender, e);
            }
            if (chb3.IsChecked == true)
            {
                this.chb3_Checked(sender, e);
            }
            if (chb4.IsChecked == true)
            {
                this.chb4_Checked(sender, e);
            }
            
        }

        private void chb2_Unchecked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "";
            validate(sender, e);
        }

        private void chb3_Unchecked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "";
            validate(sender, e);
        }

        private void chb4_Unchecked(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "";
            validate(sender, e);
        }
    }

    
}
