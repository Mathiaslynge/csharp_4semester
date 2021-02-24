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

namespace Opgave5
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

        
        private void openItem_Click(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "Open";
        }

        private void saveItem_Click(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "Save";
        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content = "Exit";
        }

        private void aboutItem_Click(object sender, RoutedEventArgs e)
        {
            statusBarItem.Content =   "About";
        }
    }
}
