using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Er ABBA et palindrom: " + "ABBA".IsPalindrom());
            Console.WriteLine("Er ABE et palindrom: " + "ABE".IsPalindrom());
            Console.ReadKey();
        }
    }
}
