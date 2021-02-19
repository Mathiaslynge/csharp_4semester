using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    public class Værkfører : Mekaniker
    {
        private int årForUdnævnelse;
        private double lønTillæg;

        public Værkfører(String navn, String adresse, int årForSvendeprøve, double løn, int årForUdnævnelse, double lønTillæg) : base(navn, adresse, årForSvendeprøve, løn)
        {
            this.årForUdnævnelse = årForUdnævnelse;
            this.lønTillæg = lønTillæg;
        }

        public int ÅrForUdnævnelse
        {
            get { return årForUdnævnelse; }
            set
            {
                if (value > 1940 && value < 2022)
                {
                    årForUdnævnelse = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("årForUdnævnelse skal være mellem 1940 og 2021", value));
                }
            }
        }
        public double LønTillæg
        {
            get { return lønTillæg; }
            set { lønTillæg = value; }
        }

        public override double UgeLøn
        {
            get { return lønTillæg + (Løn * 37); }

        }
    }

}
