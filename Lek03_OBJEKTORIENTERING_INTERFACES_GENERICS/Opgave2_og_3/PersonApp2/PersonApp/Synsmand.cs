using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    public class Synsmand : Mekaniker
    {
        private int synPrUge;
        public Synsmand(String navn, String adresse, int årForSvendeprøve, double løn, int synPrUge) : base(navn, adresse, årForSvendeprøve, løn)
        {

            this.synPrUge = synPrUge;
        }

      
        public int SynPrUge
        {
            get { return synPrUge; }
            set { synPrUge = value; }
        }

        public override double UgeLøn
        {
            get { return synPrUge * 290; }
        }
    }
}
