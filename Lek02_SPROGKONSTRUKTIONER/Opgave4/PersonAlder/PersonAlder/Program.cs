using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAlder
{
    class Program
    {

        static int ageCalc(int birthYear)
        {
            int age = 0;
            if(birthYear >= 0)
            {
                age = DateTime.Now.Year - birthYear;
            }
           
            return age;
        }
        static void Main(string[] args)
        {
            Program p1 = new Program();
            Console.WriteLine(ageCalc(1996));
            Console.ReadKey();
        }
    }
}
