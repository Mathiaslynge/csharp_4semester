using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{

   



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
                while ((line = file.ReadLine()) != null)
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
                if (x.GetWeight() > y.GetWeight())
                {
                    return 1;
                }
                else if (x.GetWeight() < y.GetWeight())
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

   

    

        static void Main(string[] args)
        {
      

            List<Person> personListe = Person.ReadCSVFile("../../data.csv");

            Console.WriteLine("______________________________________________________");
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("MIN PERSON LISTE");
            foreach (Person p in personListe)
            {
                Console.WriteLine(p);
            }


            public delegate bool Below2<in T>(T obj)    

            //personListe.Sort(new SortByAge());


        //Console.WriteLine("______________________________________________________");
        //Console.WriteLine("______________________________________________________\n SORTERET PÅ ALDER");
        //foreach (Person p in personListe)
        //{
        //    Console.WriteLine(p);
        //}

        //personListe.Sort(new SortByWeight());


        //Console.WriteLine("______________________________________________________");
        //Console.WriteLine("______________________________________________________\n SORTERET PÅ VÆGT");
        //foreach (Person p in personListe)
        //{
        //    Console.WriteLine(p);
        //}

        //personListe.Sort(new SortByName());

        //Console.WriteLine("______________________________________________________");
        //Console.WriteLine("______________________________________________________\n SORTERET PÅ NAVN");
        //foreach (Person p in personListe)
        //{
        //    Console.WriteLine(p);
        //}


        Console.ReadKey();
        }
    }
}
