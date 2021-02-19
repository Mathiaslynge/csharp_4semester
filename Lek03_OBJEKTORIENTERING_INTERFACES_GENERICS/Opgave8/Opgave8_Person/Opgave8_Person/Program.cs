using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave8_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Mathias", 24, 80.0);
            Person p2 = new Person("Nicklas", 18, 82.5);
            Person p3 = new Person("Pernille", 53, 60.3);
            Person p4 = new Person("Søren", 53, 79.6);
            Person p5 = new Person("Louise", 21, 56.2);
            Person p6 = new Person("Paul;74;72");
            ArrayList list = new ArrayList();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            list.Add(p5);
            list.Add(p6);
            Console.WriteLine($"{"Name",-10}- {"Age",-4}- {"Weight",-4}", "ColumnA", "ColumnB", "ColumnC");
            foreach(Person person in list)
            {
                Console.WriteLine(person);
            }

            Console.ReadKey();
        }
    }
}
