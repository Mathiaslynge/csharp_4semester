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

namespace Lommeregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        int number1 = 0;
        int number2 = 0;
        string symbol = "";
        public MainWindow()
        {
            InitializeComponent();
           
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txfEquation.IsReadOnly = true;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        { //btn1
            if(counter == 0)
            {
                number1 = 1;
                txfEquation.Text = "1";
                counter++;
            } else
            {
                number2 = 1;
                string value = txfEquation.Text;
                txfEquation.Text = value + "1";
                counter++;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        { //btn2
            if (counter == 0)
            {
                number1 = 2;
                txfEquation.Text = "2";
                counter++;
            }
            else
            {
                number2 = 2;
                string value = txfEquation.Text;
                txfEquation.Text = value + "2";
                counter++;
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {//btn3
            if (counter == 0)
            {
                number1 = 3;
                txfEquation.Text = "3";
                counter++;
            }
            else
            {
                number2 = 3;
                string value = txfEquation.Text;
                txfEquation.Text = value + "3";
                counter++;
            }
        }

        private void btn1_Copy_Click(object sender, RoutedEventArgs e)
        {//btn 4
            if (counter == 0)
            {
                number1 = 4;
                txfEquation.Text = "4";
                counter++;
            }
            else
            {
                number2 = 4;
                string value = txfEquation.Text;
                txfEquation.Text = value + "4";
                counter++;
            }
        }

        private void btn1_Copy1_Click(object sender, RoutedEventArgs e)
        { //btn 7
            if (counter == 0)
            {
                number1 = 7;
                txfEquation.Text = "7";
                counter++;
            }
            else
            {
                number2 = 7;
                string value = txfEquation.Text;
                txfEquation.Text = value + "7";
                counter++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            symbol = "+";
            string value = txfEquation.Text;
            txfEquation.Text = value + "+";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txfEquation.Clear();
            number1 = 0;
            number2 = 0;
            symbol = "";
            counter = 0;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            symbol = "-";
            string value = txfEquation.Text;
            txfEquation.Text = value + "-";
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            symbol = "*";
            string value = txfEquation.Text;
            txfEquation.Text = value + "*";
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            symbol = "/";
            string value = txfEquation.Text;
            txfEquation.Text = value + "/";
        }

        private void btnEquation_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (symbol.Equals("+"))
            {
              result = number1 + number2;
                
            }else if (symbol.Equals("-"))
            {
                result = number1 - number2;
            } else if (symbol.Equals("*"))
            {
                result = number1 * number2;
            } else
            {
                result = number1 / number2;
            }

            txfEquation.Text = "= " + result;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        { //btn5
            if (counter == 0)
            {
                number1 = 5;
                txfEquation.Text = "5";
                counter++;
            }
            else
            {
                number2 = 5;
                string value = txfEquation.Text;
                txfEquation.Text = value + "5";
                counter++;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        { //btn6
            if (counter == 0)
            {
                number1 = 6;
                txfEquation.Text = "6";
                counter++;
            }
            else
            {
                number2 = 6;
                string value = txfEquation.Text;
                txfEquation.Text = value + "6";
                counter++;
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        { //btn8
            if (counter == 0)
            {
                number1 = 8;
                txfEquation.Text = "8";
                counter++;
            }
            else
            {
                number2 = 8;
                string value = txfEquation.Text;
                txfEquation.Text = value + "8";
                counter++;
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        { //btn9
            if (counter == 0)
            {
                number1 = 9;
                txfEquation.Text = "9";
                counter++;
            }
            else
            {
                number2 = 9;
                string value = txfEquation.Text;
                txfEquation.Text = value + "9";
                counter++;
            }
        }
    }
}
