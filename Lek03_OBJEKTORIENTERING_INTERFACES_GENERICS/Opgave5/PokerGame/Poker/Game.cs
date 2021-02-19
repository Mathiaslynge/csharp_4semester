using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Game
    {
        private int GameId { get; set; }
        private ArrayList players = new ArrayList();
        private ArrayList cards = new ArrayList();
        private Card[] tableCards = new Card[4];

        public Game(int gameId)
        {
            this.GameId = gameId;
        }

        public ArrayList getPlayers()
        {
            return new ArrayList(players);
        }

        public void addPlayer(Player player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
            } 
        }

        public void removePlayer(Player player)
        {
            if (players.Contains(player))
            {
                players.Remove(player);
            }
        }

        public Card createCard(String color, String number)
        {
            Card card = new Card(color, number);
            cards.Add(card);
            return card;
        }

        public ArrayList getCards()
        {
            return new ArrayList(cards);
        }

        public Card[] getTableCards()
        {
            return tableCards;
        }

        public void generateTableCards()
        {
            Random rand = new Random();
            for(int i = 0; i <= 4; i++)
            {
                tableCards[i] = (Card)cards[rand.Next(52)];
            }
        }

    }
}
