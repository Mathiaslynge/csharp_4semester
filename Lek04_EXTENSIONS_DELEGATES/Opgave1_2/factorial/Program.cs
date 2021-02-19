using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    public static class Program
    {

        public static int Factorial(int n)

        {

            if (n == 0)

            {

                return 1;

            }

            return n * Factorial(n - 1);

        }

        public static int FactorialExtend(this int n)
        {
            if (n == 0) {
                return 1;
            }
            else
            {
                return n * FactorialExtend(n - 1);
            }
        }

       public static int Power(int n, int p)
        {
            if (p != 0)
            {
                return (n * Power(n, p - 1));
            }
            else
            {
                return 1;
            }
        }
    
        public static int PowerExtend(this int n, int p)
        {
            if (p != 0)
            {
                return (n * Power(n, p - 1));
            }
            else
            {
                return 1;
            }
        }

    static void Main(string[] args)
        {
            Console.WriteLine("Skriv et tal til en factorial funktion:" );
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Factorial nummer af {number} er " + Program.Factorial(4));
            Console.WriteLine();
            Console.WriteLine("Test af extend method: " + 4.FactorialExtend() );
            Console.WriteLine();
            Console.WriteLine("Skriv et tal til en Power funktion først et heltal");
             Console.WriteLine("Derefter skriv et tal som skal være eksponenten");
            int n = Int32.Parse(Console.ReadLine());
            int p = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Power af {n} med eksponenten {p} er " + Program.Power(n, p));
            Console.WriteLine();
            Console.WriteLine("Test af extend method: " + 2.PowerExtend(4));
            Console.ReadKey();
            

        }   
    }
}
