using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace opgaver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Person> data;

        public MainWindow()
        {
            InitializeComponent();
            data = new ObservableCollection<Person>() {
                new Person("Mathias", 80, 24, 100, true),
                new Person("Bob", 55, 80, 13, false),
                new Person("John", 23, 3, 54, true),
                new Person("Kurt", 65, 24, 23, false),
                new Person("Simon", 43, 45, 64, true),
            };
            lvwNames.ItemsSource = data;
            gridRight.DataContext = data;

            Binding binding = new Binding("SelectedItem.Age");
            binding.Mode = BindingMode.OneWay;
            binding.ElementName = "lvwNames";
            txtAge.SetBinding(TextBox.TextProperty, binding);

        }

        private void txtNavn_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvwNames.Items.Refresh();
        }

        private void txtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvwNames.Items.Refresh();
        }

        private void txtAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvwNames.Items.Refresh();
        }

        private void txtScore_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvwNames.Items.Refresh();
        }

        private void txtAccepted_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvwNames.Items.Refresh();
        }


    }
}
