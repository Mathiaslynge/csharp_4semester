using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Opgave10
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Saul;60;63";
            string s2 = "Bo;20;63";
            string s3 = "Per;30;63";
            string s4 = "Anders;40;63";
            string s5 = "Gunner;50;63";

            Person p1 = new Person(s1);
            Person p2 = new Person(s2);
            Person p3 = new Person(s3);
            Person p4 = new Person(s4);
            Person p5 = new Person(s5);

            List<Person> personer = new List<Person>();
            personer.Add(p1);
            personer.Add(p2);
            personer.Add(p3);
            personer.Add(p4);
            personer.Add(p5);

            foreach (object s in personer)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("");

            personer.Sort();

            foreach (object s in personer)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}