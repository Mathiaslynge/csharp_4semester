using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {


        public void Fibonacci(int grænseværdi)
        {
            int n1 = 0;
            int n2 = 1;
            int n3;

            Console.Write(n1 + " " + n2 + " ");
            for(int i = 2; i < grænseværdi; ++i)
            {
                n3 = n1 + n2;
                Console.Write(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            bool condition = false;
            while (!condition) { 
            Program p1 = new Program();
            int nummer;
            Console.WriteLine("Skriv grænseværdi for fibonnaci." + "\n" + "Hvis grænseværdi er 0 afsluttes applikationen. ");
 
            nummer = int.Parse(Console.ReadLine());
            if(nummer == 0)
            {
               condition = true;
            } else
            {
               p1.Fibonacci(nummer);
             
                }
            }
            Environment.Exit(0);

        }
    }
}   
