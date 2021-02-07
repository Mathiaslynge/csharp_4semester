using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var bytes = new Byte[5];

            rand.NextBytes(bytes); 
            foreach (byte byteValue in bytes)
            {
                Console.Write("{0, 5}", byteValue);

            }
            Console.WriteLine();

            Console.WriteLine("Five random integer values:");
            for (int ctr = 0; ctr <= 4; ctr++) { 
                Console.Write("{0,15:N0}", rand.Next());
            }
            Console.WriteLine();



            Console.WriteLine("Five random integers between 0 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++) { 
                Console.Write("{0,8:N0}", rand.Next(101));
            }
            Console.WriteLine();
 

            Console.WriteLine("Random.Next og random.NextDouble: ");
            int month = rand.Next(1, 13);  // creates a number between 1 and 12
            int dice = rand.Next(1, 7);   // creates a number between 1 and 6
            int card = rand.Next(52);     // creates a number between 0 and 51
            Console.WriteLine("Month: " + month + "\n Dice: " + dice + "\n Card: " + card);
            Console.ReadKey();
        }
    }
}
