using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spillekort
{
    class Collection
    {

        private ArrayList Cards = new ArrayList();

        public Collection()
        {
     
        }

        public Card createCard(String color, String number)
        {
            Card card = new Card(color, number);
            Cards.Add(card);
            return card;
        }


        public ArrayList getCards()
        {
            return Cards;
        }

        public delegate bool Comparator(int e1, int e2);


        public static bool greaterThan(int a, int b)
        {
            return a > b;
        }

        private static void swap(ArrayList list, int i, int j)
        {

            Card temp2 = (Card)list[i];
            int temp = Int32.Parse(temp2.getNumber());
            list[i] = list[j];
            list[j] = temp;
        }


        public void SortCollection(Comparator Compare)
        {
            for (int i = Cards.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    Card testj = (Card)Cards[j];
                    Card testj1 = (Card)Cards[j + 1];
                    if (Compare(Int32.Parse(testj.getNumber()), Int32.Parse(testj1.getNumber())))
                    {

                        swap(Cards, j, j + 1);
                    }
                }
            }
        }


    }
}
