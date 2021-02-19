
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spillekort
{
    class Program
    {
        static void Main(string[] args)
        {
            Collection cardColl = new Collection();
            Card c1 = new Card("Diamonds", "2");


            String farven = "";
            for (int i = 0; i <= 3; i++) {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 0)
                    {
                        farven = "Hearts";
                    } else if (i == 1)
                    {
                        farven = "Diamonds";
                    } else if (i == 2)
                    {
                        farven = "Clubs";
                    } else if (i == 3)
                    {
                        farven = "Spades";
                    }
                    if (j > 5)
                    {
                        if (j == 6)
                        {
                            cardColl.createCard(farven, "Ten");
                        }
                        else if (j == 7)
                        {
                            cardColl.createCard(farven, "Jack");
                        }
                        else if (j == 8)
                        {
                            cardColl.createCard(farven, "Queen");
                        } else if (j == 9)
                        {
                            cardColl.createCard(farven, "King");
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            cardColl.createCard(farven, "ACE");
                        }
                        cardColl.createCard(farven, $"{j}");
                    }
                }

            }


            Console.WriteLine(cardColl.getCards()[8]);
            Console.WriteLine(cardColl.getCards().Count);

            foreach (Card element in cardColl.getCards())
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("EFTER SORTERING");

            cardColl.SortCollection(Collection.greaterThan);
            foreach (Card element in cardColl.getCards())
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
            }

        }
    }
