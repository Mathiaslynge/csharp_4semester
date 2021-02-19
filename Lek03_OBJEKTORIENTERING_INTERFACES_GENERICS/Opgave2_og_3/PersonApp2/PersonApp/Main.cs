using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Jens", "Nyvej 1");
            Mekaniker m1 = new Mekaniker("Otto", "Næsehornsvej 23", 1996, 200);
            Mekaniker m2 = new Mekaniker("Mikkel", "Håndboldvej 55", 2009, 150);
            Værkfører v1 = new Værkfører("Peter", "Savsmuldsvej 23", 2005, 210, 2015, 30);
            Synsmand s1 = new Synsmand("Bent", "Brillevej 20", 1966, 0, 10);

            Console.WriteLine($"{p1.Navn} er en person \n{m1.Navn} er mekaniker \n{m2.Navn} blev svend i {m2.ÅrForSvendeprøve} " +
                $"\n{v1.Navn} er værkfører og bor på {v1.Adresse} \n{s1.Navn} bor på {s1.Adresse}, er synsmand og får {s1.Løn} pr uge ");

            Mekaniker[] personListe = { m1, m2, v1, s1 };


            Console.WriteLine();
            foreach (Mekaniker element in personListe)
            {
                Console.WriteLine($"Ugeløn for {element.Navn} er {element.UgeLøn}");
            }
            Console.ReadKey();
        }
    }
}
