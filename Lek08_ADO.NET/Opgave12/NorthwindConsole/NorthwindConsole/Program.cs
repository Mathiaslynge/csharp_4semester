using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindConsole
{

    public class DBReader1
    {
        // The simplest possible way to do ADO
        public DBReader1()
        {
            ReadData(Properties.Settings1.Default.connString);
        }

        private void ReadData(string connectionString)
        {
            string queryString = "SELECT AVG(Orders.Freight) FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;

                            for (int i = 0; i < record.FieldCount; ++i)
                            {
                                Console.WriteLine("Average of all freights is " + record[0]); // record[i].GetType()
                            }

                 
                        }
                    }
                }
            }
        }
    }

    public class DBReader2
    {
        // The simplest possible way to do ADO
        public DBReader2()
        {
            ReadData(Properties.Settings1.Default.connString);
        }

        private void ReadData(string connectionString)
        {
            string queryString = "SELECT Freight FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        double sum = 0;
                        int noOfFreights = 0;
                        while (reader.Read())
                        {
                            IDataRecord record = (IDataRecord)reader;
                          
                            for (int i = 0; i < record.FieldCount; ++i)
                            {
                                noOfFreights++;
                                double freight = Decimal.ToDouble((Decimal)record[0]);
                                sum += freight;
                               }


                        }

                        Console.WriteLine($"Average of all freights is {sum / noOfFreights}");

                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1:");
            var calculate1 = new DBReader1();
            Console.WriteLine("2:");
            var calculate2 = new DBReader2();


            Console.ReadKey();
        }
    }
}
