using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave12
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var numbers = new int[100];
            for(int i = 0; i < 100; i++)
            {
                numbers[i] = rand.Next(0, 1000);
            }


            var oddNumbers =
                 (from num in numbers
                 where num % 2 != 0
                 orderby num
                 select num);

            Console.WriteLine("ODD NUMBERS: " + oddNumbers.Count());

            
            var distinct = numbers.Distinct();

            Console.WriteLine("DISTINCT: " + distinct.Count());

            Console.WriteLine("----------ODD Number ------------ ");
            int[] array = oddNumbers.ToArray<int>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(array[i]);
            }


            Console.WriteLine("----------ODD Number distinct------------ ");
            int[] array2 = oddNumbers.Distinct().ToArray<int>();
            foreach(int i in array2)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
