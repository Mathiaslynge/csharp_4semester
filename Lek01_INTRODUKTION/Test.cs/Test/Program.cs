using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv noget du vil addere, multiplicere eller substrahere" + "\n");
            Console.WriteLine("Skriv tallene som følgende: 'x+x' eller 'x-x' eller 'x*x'");
            Console.ReadKey();


            var ligning = Console.ReadLine();

            if (ligning.Contains("+"))
            {
                String[] words = ligning.Split("+");

                Console.WriteLine("Regnestykket giver: " + (Int32.Parse(words[0]) + Int32.Parse(words[1])));
            }
            else if (ligning.Contains("-"))
            {
                String[] words = ligning.Split("-");
                Console.WriteLine("Regnestykket giver: " + (Int32.Parse(words[0]) - Int32.Parse(words[1])));
            }
            else if (ligning.Contains("*"))
            {
                String[] words = ligning.Split("*");
                Console.WriteLine("Regnestykket giver: " + (Int32.Parse(words[0]) * Int32.Parse(words[1])));
            }
            Console.ReadKey();
        }
    }
}
