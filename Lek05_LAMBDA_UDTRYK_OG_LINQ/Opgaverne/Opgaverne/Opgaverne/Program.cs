using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp_Files_and_Strings
{

    public delegate int ComparePeopleDelegate(Person p1, Person p2);


    public static class Extentions
    {
        public static void Reset(this List<Person> people)
        {
            foreach (var p in people)
            {
                p.Accepted = false;
            }
        }

        public static void UpdatePeople(this List<Person> people)
        {
            foreach (var p in people)
            {

                if (p.Score >= 6 && p.Age <= 40)
                {
                    p.Accepted = true;
                }
            }


        }
    }

    public class Person
    {
        public Person(string name, int age, int weight, int score)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Score = score;
            //Accepted = true;

        }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Score { get; set; }
        public bool Accepted { get; set; }
        public override string ToString()
        {
            return $"{Name};{Age};{Weight};{Score};{Accepted}";
        }
    }
    public class ComparePeople : IComparer<Person>
    {

        private ComparePeopleDelegate comparisonMethod;

        public ComparePeople(ComparePeopleDelegate comparer)
        {
            comparisonMethod = comparer;
        }

        public int Compare(Person x, Person y)
        {
            return comparisonMethod(x, y);
        }
    }

    static class Program
    {

        public static List<string> ReadFileLines(string filename)
        {
            List<string> result = new List<string>();
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
        }
        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> personList = new List<Person>();
            List<string> fileLines = ReadFileLines(filename);
            foreach (string line in fileLines)
            {
                string[] fieldValues = line.Split(';');
                string name = fieldValues[0];
                int age = int.Parse(fieldValues[1]);
                int weight = int.Parse(fieldValues[2]);
                int score = int.Parse(fieldValues[3]);
                personList.Add(new Person(name, age, weight, score));
            }

            return personList;
        }

        static void Main(string[] args)
        {
            // Read all people from file
            List<Person> people = ReadCSVFile("../../data.csv");
            List<Person> people2 = ReadCSVFile("../../data2.csv");


            // OPGAVE 1
            Console.WriteLine("Opgave1" + "\n");

            ComparePeople comparerObj = new ComparePeople((Person a, Person b) => a.Name.CompareTo(b.Name));
            people.Sort(comparerObj);
            List<Person> result = people.FindAll(element => element.Score < 2);
            List<Person> result1 = people.FindAll(element => element.Score % 2 == 0);
            List<Person> result2 = people.FindAll(element => element.Score < 2 && element.Weight > 60);
            List<Person> result3 = people.FindAll(element => element.Weight % 3 == 0);







            Console.WriteLine("Number of people in data file : " + result3.Count);

            //Opgave 2
            Console.WriteLine("Opgave2" + "\n");

            int resultFindIndex1 = people.FindIndex(element => element.Score == 3);
            Console.WriteLine(resultFindIndex1);

            int resultFindIndex2 = people.FindIndex(element => element.Age < 10 && element.Score == 3);
            Console.WriteLine(resultFindIndex2);
            int resultFindIndex3 = people.FindAll(element => element.Age < 10 && element.Score == 3).Count;
            Console.WriteLine(resultFindIndex3);
            int resultFindIndex4 = people.FindIndex(element => element.Age < 8 && element.Score == 3);
            Console.WriteLine(resultFindIndex4);

            //Opgave 3

            Comparison<Person> personNameAscending = (Person a, Person b) => a.Name.CompareTo(b.Name);
            Comparison<Person> personNameDescending = (Person a, Person b) => b.Name.CompareTo(a.Name);
            Comparison<Person> personAgeAscending = (Person a, Person b) => a.Age.CompareTo(b.Age);
            Comparison<Person> personAgeDescending = (Person a, Person b) => b.Age.CompareTo(a.Age);


            people.Sort(personAgeDescending);

            Console.WriteLine("Opgave3" + "\n");

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }


            Console.WriteLine("--------Opgave 4--------");
            //Opgave 4
            people.UpdatePeople();
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }




            //OPGAVE 8

            Console.WriteLine("Opgave8" + "\n");


            //Ascending
            var Query1 =
                from p in people
                orderby p.Score
                select p;

            //Descending
            var Query2 =
                from p in people
                orderby -p.Score
                select p;


            foreach (Person i in Query1)
            {
                Console.WriteLine(i);
            }

            //Opgave 9
            Console.WriteLine("Opgave9" + "\n");

            var avg = (from p in people
                       select p.Age).Average();


            var Query3 =
                from p in people
                orderby p.Age - avg
                select p;

            foreach (Person i in Query3)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("___________________________");

            //Opgave 10
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };


            //Opgave10.1
            Console.WriteLine("Opgave10.1/2" + "\n");

            var Query4_1 =
                from num in numbers
                where num < 99 && num > 9
                orderby num
                select num;


            foreach (int i in Query4_1)
            {
                Console.WriteLine(i);
            }

            //Opgave10.3
            Console.WriteLine("Opgave10.3" + "\n");
            var Query4_3 =
              from num in numbers
              where num < 99 && num > 9
              orderby num
              select num.ToString();


            foreach (string i in Query4_3)
            {
                if (Int32.Parse(i) % 2 == 0)
                {
                    Console.WriteLine(i + " Even");
                }
                else
                {
                    Console.WriteLine(i + " Uneven");
                }

            }


            //Opgave 11
            Console.WriteLine("Opgave11" + "\n");
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("_________________________________");

            people.Reset();

            foreach (var p in people)
            {
                Console.WriteLine(p);
            }


            Console.WriteLine("-----------FIRST LETTER-----------");

            var firstLetter =
                from p in people
                group p by p.Name into newGroup
                orderby newGroup.Key
                select newGroup;


            foreach (var nameGroup in firstLetter)
            {
                Console.WriteLine($"{nameGroup.Key}");

            }


            //OPGAVE14
            Console.WriteLine("---------opgave 14---------");



            var res = from p1 in people
                      join p2 in people2 on p1.Name equals p2.Name
                      select new { Navn = p1.Name };

            foreach (var p in res)
            {
                Console.WriteLine(p);

            }

            Console.ReadKey();



        }



    }
}



