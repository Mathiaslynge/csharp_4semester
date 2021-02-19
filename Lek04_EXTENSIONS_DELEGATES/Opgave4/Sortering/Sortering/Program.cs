using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortering
{
    class delegateopgave
    {


        public delegate bool Comparator(int e1, int e2);


        public static bool greaterThan(int a, int b)
        {
            return a > b;
        }

        // sorter array ved hjælp af Comparator delegate

        private static void swap(int[] list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public static void SortArray(int[] array, Comparator Compare)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (Compare(array[j], array[j + 1])) { 

                        swap(array, j, j + 1);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] intArray = { 5, 67, 45, 23, 99, 44, 56, 12, 3, 44 };

            delegateopgave.SortArray(intArray, delegateopgave.greaterThan);

            foreach (int i in intArray)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
