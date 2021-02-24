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

namespace Opgave1_2
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

  

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            hellloworld1.IsEnabled = true;
            helloworld2.IsEnabled = false;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            helloworld2.IsEnabled = true;
            hellloworld1.IsEnabled = false;
        }

        private void hellloworld1_Click(object sender, RoutedEventArgs e)
        {
            if (hellloworld1.IsEnabled)
            {
                string temp = text1.Content.ToString();
                text1.Content = text2.Content.ToString();
                text2.Content = temp;

            }
        }



        private void helloworld2_Click(object sender, RoutedEventArgs e)
        {
            if (helloworld2.IsEnabled)
            {
                string temp = text3.Content.ToString();
                text3.Content = text4.Content.ToString();
                text4.Content = temp;

            }

        }
    }
}
