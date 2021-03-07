using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo1 {


    /*
     * 
     * Using
     * Properties.Settings.Default.connString
     * SqlConnection
     * SqlCommand
     * SqlDataReader
     * IDataRecord
     * 
     */
    public class DBReader1 {
        // The simplest possible way to do ADO
        public DBReader1() {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadData(string connectionString) {
            string queryString = "SELECT * FROM Persons";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
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
                                Console.WriteLine(String.Format("{0}, {1}, {2}", record.GetDataTypeName(i), record.GetName(i), record[i])); // record[i].GetType()
                            }

                            int id = (int)record[0];
                            string name = (string)record[1];
                            int age = (int)record[2];
                            int weight = (int)record[3];
                            int score = (int)record[4];

                            // Do stuff with data
                        }
                    }
                }
            }
        }
    }

    /*
     * Using
     * DataTable
     * 
     */
    public class DBReader2 {

        public DBReader2() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            DataTable dataTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        // this will query your database and return the result to your datatable
                        da.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            Console.WriteLine($"ID={id},Name={name},Age={age},Weight={weight},Score={score}");
                        }

                        // Using LINQ
                        var q = from row in dataTable.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");

                    }
                }
            }
        }
    }

    public class DBReader3 {

        public DBReader3() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT * FROM Persons";

            //DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet dataSet = new DataSet("Persons");
                        da.Fill(dataSet);
                        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                            Console.WriteLine(dataSet.Tables[0].Rows[i]["Name"].ToString());

                        string tableName = dataSet.Tables[0].TableName;
                        DataTable table = dataSet.Tables["Table"];
                        foreach (DataRow row in table.Rows)
                        {
                            int id = (int)row["ID"];
                            string name = (string)row["Name"];
                            int age = (int)row["Age"];
                            int weight = (int)row["Weight"];
                            int score = (int)row["Score"];

                            // Do lots of funny stuff with dataTable
                        }

                        var q = from row in table.AsEnumerable()
                                where row.Field<int>("Age") > 40
                                select new
                                {
                                    ID = row.Field<int>("ID"),
                                    Name = row.Field<string>("Name"),
                                };
                        foreach (var obj in q)
                            Console.WriteLine($"ID={obj.ID}, Name={obj.Name}");
                    }
                }
            }                
        }
    }

    // SELECT Persons.ID, Persons.Name, Pets.Name FROM Persons
    // INNER JOIN Pets ON Persons.ID = Pets.owner_id;
    public class DBReader4 {

        public DBReader4() {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString) {
            string query = "SELECT Persons.Name, Pets.Name FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows) {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;
                
                var PersonName = (string)row[c0];
                var PetName = (string)row[c1];

                Console.WriteLine($"PersonName={PersonName}, PetName={PetName}");

               
            }


            conn.Close();
            da.Dispose();
        }
    }

    public class DBWriter5 {

        public DBWriter5() {
            WriteData1(Properties.Settings.Default.connString);
            WriteData2(Properties.Settings.Default.connString);
            WriteData3(Properties.Settings.Default.connString);
            WriteData4(Properties.Settings.Default.connString);
        }

        public void WriteData1(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (21,'Anton',34,64,8)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void WriteData2(string connectionString) {

            string query = "INSERT INTO Persons (ID,Name,Age,Weight,Score) VALUES (@ID,@Name,@Age,@Weight,@Score)";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;
                    command.Parameters.Add("@Name", SqlDbType.VarChar, 250).Value = "Anton";
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = 34;
                    command.Parameters.Add("@Weight", SqlDbType.Int).Value = 64;
                    command.Parameters.Add("@Score", SqlDbType.Int).Value = 8;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


            //--DELETE FROM Persons WHERE ID = 21;
            //--UPDATE Pets SET Weight = 24 WHERE Name = 'Garfield';

        }

        public void WriteData3(string connectionString) {

            string query = "DELETE FROM Persons WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = 22;                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void WriteData4(string connectionString) {

            string query = "UPDATE Persons SET Age = 39 WHERE ID = 21";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }

    public class Øvelse3
    {
        public Øvelse3()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        private void ReadData(string connectionString)
        {
            string queryString = "SELECT * FROM Persons";

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

                           

                            int id = (int)record[0];
                            string name = (string)record[1];
                            int age = (int)record[2];
                            int weight = (int)record[3];
                            int score = (int)record[4];
                            Console.WriteLine(String.Format("ID = {0,-6} Name = {1,-10} Points = {2,-8} years = {3, -10}  kg = {3, -10}", id, name, score, age, weight));
                            // Do stuff with data
                        }
                    }
                }
            }
        }
    }

    public class Øvelse4
    {
        public Øvelse4()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString)
        {
            string query = "SELECT Persons.ID, Persons.Name, Pets.ID, Pets.Name FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id";

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;
                var c2 = row.Table.Columns[2].ColumnName;
                var c3 = row.Table.Columns[3].ColumnName;

                var PersonID = (int)row[c0];
                var PersonName = (string)row[c1];
                var PetID = (int)row[c2];
                var PetName = (string)row[c3];

                Console.WriteLine($"PersonID={PersonID}, PersonName={PersonName}, PetID={PetID}, PetName={PetName}");


            }


            conn.Close();
            da.Dispose();
        }
    }


    public class Øvelse5
    {
        public Øvelse5()
        {
            ReadData(Properties.Settings.Default.connString);
        }

        public void ReadData(string connectionString)
        {
            string query = "SELECT Persons.ID, Persons.Name, MAX(Persons.Score) FROM Persons INNER JOIN Pets ON Persons.ID = Pets.owner_id group by Persons.ID, Persons.Name, Pets.ID, Pets.Name";
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                var c0 = row.Table.Columns[0].ColumnName;
                var c1 = row.Table.Columns[1].ColumnName;
                var c2 = row.Table.Columns[2].ColumnName;
               

                var PersonID = (int)row[c0];
                var PersonName = (string)row[c1];
                var maxScore = (int)row[c2];
                

                Console.WriteLine($"PersonID={PersonID}, PersonName={PersonName}, Max Score={maxScore} has pet");


            }


            conn.Close();
            da.Dispose();
        }
    }

    public class Øvelse6
    {

        public Øvelse6()
        {
            Garfield(Properties.Settings.Default.connString);
            ReadData(Properties.Settings.Default.connString);
    
        }

        public void Garfield(string connectionString)
        {

            string query = "UPDATE Pets SET Weight = 24 WHERE ID = 4";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ReadData(string connectionString)
        {

            string query = "Select * from Pets WHERE id = 4";
            

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

                            int id = (int)record[0];
                            string name = (string)record[2];
                            int age = (int)record[3];
                            int weight = (int)record[4];
                            string species = (string)record[5];
                            Console.WriteLine(String.Format("ID = {0,-6} Name = {1,-10} Points = {2,-8} years = {3, -10}  kg = {3, -10}", id, name, species, age, weight));
                            // Do stuff with data
                        }
                    }
                }
            }
        }

    }

    public class Øvelse7
    {

        public Øvelse7()
        {
            EdisonAlfred(Properties.Settings.Default.connString);
            ReadData(Properties.Settings.Default.connString);

        }

        public void EdisonAlfred(string connectionString)
        {

            string query = "INSERT INTO Pets (ID, owner_id, Name,Age,Weight,Species) VALUES (7, 17, 'Alfred', 1, 1, 'Cat')";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ReadData(string connectionString)
        {

            string query = "Select * from Pets";


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

                            int id = (int)record[0];
                            string name = (string)record[2];
                            int age = (int)record[3];
                            int weight = (int)record[4];
                            string species = (string)record[5];
                            Console.WriteLine(String.Format("ID = {0,-6} Name = {1,-10} Points = {2,-8} years = {3, -10}  kg = {3, -10}", id, name, species, age, weight));
                            // Do stuff with data
                        }
                    }
                }
            }
        }

    }

    public class Øvelse8
    {

        public Øvelse8()
        {
            DeleteWyatt(Properties.Settings.Default.connString);
            ReadData(Properties.Settings.Default.connString);

        }

        public void DeleteWyatt(string connectionString)
        {

            string query = "DELETE FROM Persons WHERE ID = 8";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ReadData(string connectionString)
        {

            string query = "Select * from Persons";


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

                            int id = (int)record[0];
                            string name = (string)record[1];
                         
                            Console.WriteLine(String.Format("ID = {0,-6} Name = {1,-10} ", id, name));
                            // Do stuff with data
                        }
                    }
                }
            }
        }

    }

    public class Øvelse9
    {
        public Øvelse9()
        {
            DataTableFill(Properties.Settings.Default.connString);
        }

        public void DataTableFill(string connectionString)
        {
            string queryPersons = "SELECT * FROM Persons";
            string queryPets = "SELECT * FROM Pets";
            DataTable dataTablePersons = new DataTable();
            DataTable dataTablePets = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmdPersons = new SqlCommand(queryPersons, conn);
            SqlCommand cmdPets = new SqlCommand(queryPets, conn);
            conn.Open();

            SqlDataAdapter daPersons = new SqlDataAdapter(cmdPersons);
            daPersons.Fill(dataTablePersons);
            SqlDataAdapter daPets = new SqlDataAdapter(cmdPets);
            daPets.Fill(dataTablePets);

            var JoinResult = (from persons in dataTablePersons.AsEnumerable()
                              join pets in dataTablePets.AsEnumerable()
                              on persons.Field<int>("ID") equals pets.Field<int>("owner_id")
                              select new
                              {
                                  Id = persons.Field<int>("ID"),
                                  Name = persons.Field<string>("Name"),
                                  PetId = pets.Field<int>("ID"),
                                  PetName = pets.Field<string>("Name")
                              }).ToList();

            foreach (var element in JoinResult)
            {
           
                Console.WriteLine(String.Format("ID = {0,-6} Name = {1,-10} PetID = {2, -6} PetName = {3, -10} ", element.Id, element.Name, element.PetId, element.PetName));



            }


            conn.Close();
            daPersons.Dispose();
            daPets.Dispose();
        }
    }

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("connString : " + Properties.Settings.Default.connString);

            Console.WriteLine("Running DBReader1");
            //var reader1 = new DBReader1();

            Console.WriteLine("Running DBReader2");
            //var reader2 = new DBReader2();

            Console.WriteLine("Running DBReader3");
            //var reader3 = new DBReader3();

            Console.WriteLine("Running DBReader4");
            //var reader4 = new DBReader4();

            Console.WriteLine("Running DBWriter5");
            //var writer5 = new DBWriter5();

            Console.WriteLine("Running Øvelse3");
            //var øvelse3 = new Øvelse3();

            Console.WriteLine("Running Øvelse4");
            //var øvelse4 = new Øvelse4();

            Console.WriteLine("Running Øvelse5");
            //var øvelse5 = new Øvelse5();

            Console.WriteLine("Running Øvelse6");
            //var øvelse6 = new Øvelse6();

            Console.WriteLine("Running Øvelse7");
            //var øvelse7 = new Øvelse7();

            Console.WriteLine("Running Øvelse8");
            //var øvelse8 = new Øvelse8();

            Console.WriteLine("Running Øvelse9");
            var øvelse9 = new Øvelse9();

            Console.ReadKey();
        }

    }
}
