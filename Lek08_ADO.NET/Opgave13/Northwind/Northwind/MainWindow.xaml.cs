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
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.ObjectModel;

namespace Northwind
{

    public class DBReader1
    {
        // The simplest possible way to do ADO
        public DBReader1()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        public List<string> ReadData(string connectionString)
        {
            string query = "SELECT DISTINCT Customers.Country from Customers";
            DataTable dataTableCountries = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmdCountries = new SqlCommand(query, conn);
        
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmdCountries);
            da.Fill(dataTableCountries);

            List<string> countriesList = new List<string>();

            for(int i = 0; i < dataTableCountries.Rows.Count; i++)
            {
                countriesList.Add(dataTableCountries.Rows[i]["Country"]+"");
            }

            conn.Close();
            da.Dispose();
            return countriesList;
        }
    }

    public class DBReader2
    {

        // The simplest possible way to do ADO
        public DBReader2()
        {
           
        }

        public List<string> ReadData(string connectionString, string country)
        {
            string query = $"SELECT Customers.ContactName, Customers.City from Customers where Customers.Country = '{country}'";
            DataTable datatableCustomers = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmdCustomers = new SqlCommand(query, conn);

            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmdCustomers);
            da.Fill(datatableCustomers);

            List<string> customerList = new List<string>();

            for (int i = 0; i < datatableCustomers.Rows.Count; i++)
            {
                customerList.Add(datatableCustomers.Rows[i]["ContactName"] + " - " + datatableCustomers.Rows[i]["City"]);
            }

            conn.Close();
            da.Dispose();
            return customerList;
        }


        public List<string> ReadData2(string connectionString, string country)
        {

            string query = $"SELECT Customers.ContactName, Customers.City from Customers where Customers.Country = '{country}'";

            List<string> customerList = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                 
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;

                            customerList.Add((string)record[0] + " - " + (string)record[1]);

                        }
                    }
                }
            }
            return customerList;
        }
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<string> customerData = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            lvwCustomers.ItemsSource = customerData;
            rowBottom.DataContext = customerData;
            
            var countryData = new DBReader1();
            var data = countryData.ReadData(Properties.Settings.Default.connString);
            var dataOC = new ObservableCollection<string>();
            foreach(var element in data)
            {
                dataOC.Add(element);
            }

            cbbCountries.ItemsSource = dataOC;
            rowTop.DataContext = dataOC;
         
        }

        private void cbbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var customers = new DBReader2();
            //var data = customers.ReadData2(Properties.Settings.Default.connString, cbbCountries.Text);
            //customerData.Clear();
            //foreach (var element in data)
            //{
            //    customerData.Add(element);
            //}
   
            //lvwCustomers.Items.Refresh();
          
          //DROPDOWNCLOSED ER 1000000 gange bedre!

        }

        private void cbbCountries_DropDownClosed(object sender, EventArgs e)
        {
            var customers = new DBReader2();
            var data = customers.ReadData2(Properties.Settings.Default.connString, cbbCountries.Text);
            customerData.Clear();
            foreach (var element in data)
            {
                customerData.Add(element);
            }

            lvwCustomers.Items.Refresh();

        }
    }

   
}
