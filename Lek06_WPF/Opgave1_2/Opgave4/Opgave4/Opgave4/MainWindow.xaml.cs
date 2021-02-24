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

namespace Opgave4
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

        string[] btnTexts;

        private void btnBottom_Click(object sender, RoutedEventArgs e)
        {
            TxtBlock.Text += "\n" + btnBottom.Content.ToString();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            TxtBlock.Text += "\n" + btnLeft.Content.ToString();

        }

        private void btnTop_Click(object sender, RoutedEventArgs e)
        {
            TxtBlock.Text += "\n" + btnTop.Content.ToString();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            TxtBlock.Text += "\n" + btnRight.Content.ToString();
        }
    }
}
