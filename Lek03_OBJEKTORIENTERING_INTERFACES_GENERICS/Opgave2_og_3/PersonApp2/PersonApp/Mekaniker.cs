using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    public class Mekaniker : Person
    {
        private int årForSvendeprøve;
        private double løn;

        public Mekaniker(String navn, String adresse, int årForSvendeprøve, double løn) : base(navn, adresse)
        {
            this.årForSvendeprøve = årForSvendeprøve;
            this.løn = løn;
        }

        public int ÅrForSvendeprøve
        {
            get { return årForSvendeprøve; }
            set
            {
                if (value > 1940 && value < 2022)
                {
                    årForSvendeprøve = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("årForSvendeprøve skal være mellem 1940 og 2021", value));
                }
            }
        }
        public double Løn
        {
            get { return løn; }
            set { løn = value; }
        }

        public virtual double UgeLøn
        {
            get { return løn * 37; }
        }
    }
}
