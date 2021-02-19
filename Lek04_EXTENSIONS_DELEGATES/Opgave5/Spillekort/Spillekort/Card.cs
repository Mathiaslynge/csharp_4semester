using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spillekort
{
    class Card
    {
        private String CardColor { get; set; }
        private String Number { get; set; }

        public Card(String cardColor, String number)
        {
            this.CardColor = cardColor;
            this.Number = number;
        }

        public override String ToString()
        {
            return $"{Number} {CardColor}";
        }

        public String getNumber()
        {
            return Number+"";
        }
    }

}