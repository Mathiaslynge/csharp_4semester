using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{

    public class DataBlock
    {
        public DataBlock(int id, double number)
        {
            Id = id;
            Number = number;
        }
        public int Id { get; set; }
        public double Number { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, Number:{Number}";
        }
    }
    public class SortById : IComparer<DataBlock>
    {
        // Read this
        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=netframework-4.7.2
        //
        public int Compare(DataBlock x, DataBlock y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
    


    public class Person
    {
        string Name;
        int Age, Weight;

        public Person(string name, int age, int weight)
        {
            this.Age = age;
            this.Weight = weight;
            this.Name = name;
        }

        public Person(string s)
        {
            string[] S = s.Split(';');
            this.Name = S[0];
            this.Age = Int32.Parse(S[1]);
            this.Weight = Int32.Parse(S[2]);
        }

        public Int32 GetWeight()
        {
            return Weight;
        }

        public Int32 GetAge()
        {
            return Age;
        }

        public String GetName()
        {
            return Name;
        }

        public override string ToString()
        {
            return Name + ", " + Age + ", " + Weight;
        }

        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> PersonListe = new List<Person>();
            using (var file = new StreamReader(filename))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    string[] S = line.Split(';');
                    string name = S[0];
                    int age = Int32.Parse(S[1]);
                    int weight = Int32.Parse(S[2]);
                    PersonListe.Add(new Person(name, age, weight));
                }
            }
            return PersonListe;
        }
      
    }


    public class SortByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            try
            {
                if (x.GetAge() > y.GetAge())
                {
                    return 1;
                }
                else if (x.GetAge() < y.GetAge())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }

        }
    }
    public class SortByWeight : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            try
            {
                if(x.GetWeight() > y.GetWeight())
                {
                    return 1;
                } else if (x.GetWeight() < y.GetWeight())
                {
                    return -1;
                } else
                {
                    return 0;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
         
        }
    }
    public class SortByName : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            try
            {
                if (x.GetName().CompareTo(y.GetName()) > 0)
                {
                    return 1;
                }
                else if (x.GetName().CompareTo(y.GetName()) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }

        }
    }

    class Program
    {

        public static void ReadFile(string filename)
        {
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static string[] SplitString(string txt)
        {
            var res = txt.Split(';');
            foreach (var s in res)
            {
                //Console.WriteLine("<" + s + ">");
                Console.WriteLine("<" + s.Trim() + ">");
            }
            return res;
        }

        public static void ParseNumbers(string txt)
        {
            string[] numbers = SplitString(txt);
            foreach (var n in numbers)
            {
                int resi;
                if (int.TryParse(n, out resi))
                {
                    Console.WriteLine("Got integer : " + resi);
                    continue;
                }
                double resd;
                if (double.TryParse(n, out resd))
                {
                    Console.WriteLine("Got double : " + resd);
                    continue;
                }
            }
        }

        public static List<DataBlock> GetListOfDataBlocks()
        {
            var lst = new List<DataBlock>() {
                new DataBlock(55,34),
                new DataBlock(49,51),
                new DataBlock(76,40),
                new DataBlock(6,51),
                new DataBlock(78,90),
                new DataBlock(27,3),
                new DataBlock(57,66),
                new DataBlock(51,63),
                new DataBlock(24,38),
                new DataBlock(33,68),
            };
            return lst;
        }

        static void Main(string[] args)
        {
            ReadFile("../../data.csv"); // Remember to set up path to file

            Console.WriteLine("--------------------------------------------------");
            SplitString("string;txt;  anton  ;22  ;  56;shit er det hjemis bilen...farvel");

            Console.WriteLine("--------------------------------------------------");
            ParseNumbers("34;54;655,45");

            List<DataBlock> dataBlocks = GetListOfDataBlocks();
            dataBlocks.Sort(new SortById());
            foreach (var db in dataBlocks)
                Console.WriteLine(db);

            string s = "Saul;60;63";
            var person = new Person(s);
            Console.WriteLine(person.ToString());

            List<Person> personListe = Person.ReadCSVFile("../../data.csv");

            Console.WriteLine("______________________________________________________");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("MIN PERSON LISTE");
            foreach(Person p in personListe)
            {
                Console.WriteLine(p);
            }

            personListe.Sort(new SortByAge());


            Console.WriteLine("______________________________________________________");
            Console.WriteLine("______________________________________________________\n SORTERET PÅ ALDER");
            foreach(Person p in personListe)
            {
                Console.WriteLine(p);
            }

            personListe.Sort(new SortByWeight());


            Console.WriteLine("______________________________________________________");
            Console.WriteLine("______________________________________________________\n SORTERET PÅ VÆGT");
            foreach (Person p in personListe)
            {
                Console.WriteLine(p);
            }

            personListe.Sort(new SortByName());

            Console.WriteLine("______________________________________________________");
            Console.WriteLine("______________________________________________________\n SORTERET PÅ NAVN");
            foreach (Person p in personListe)
            {
                Console.WriteLine(p);
            }


            Console.ReadKey();
        }
    }
}
