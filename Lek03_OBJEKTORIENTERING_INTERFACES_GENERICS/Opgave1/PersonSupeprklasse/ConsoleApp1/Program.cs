using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    public class Person 
    {
        private String navn;
        private String adresse;

        public Person(String navn, String adresse)
        {
            this.navn = navn;
            this.adresse = adresse;
        }

        public String Navn
        {
            get {return navn; }
            set {navn = value;}
        }

        public String Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
       
    }

    public class Mekaniker: Person
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
            set { if(value > 1940 && value < 2022)
                {
                    årForSvendeprøve = value;
                } else
                {
                    throw new ArgumentException(String.Format("årForSvendeprøve skal være mellem 1940 og 2021", value));
                }
               }
        }
        public virtual double Løn
        {
            get { return løn; }
            set { løn = value; }
        }
    }

    public class Værkfører: Mekaniker
    {
        private int årForUdnævnelse;
        private double lønTillæg;

        public Værkfører(String navn, String adresse, int årForSvendeprøve, double løn, int årForUdnævnelse, double lønTillæg): base(navn, adresse, årForSvendeprøve, løn)
        {
            this.årForUdnævnelse = årForUdnævnelse;
            this.lønTillæg = lønTillæg;
        }

        public int ÅrForUdnævnelse
        {
            get { return årForUdnævnelse; }
            set { if(value> 1940 && value < 2022)
                {
                    årForUdnævnelse = value;
                }  else
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
    }

    public class Synsmand: Mekaniker
    {
        private int synPrUge;
        public Synsmand(String navn, String adresse, int årForSvendeprøve, double løn, int synPrUge): base(navn, adresse, årForSvendeprøve, løn)
        {
            
            this.synPrUge = synPrUge;
        }

        public override double Løn
        {
            get { return synPrUge *290 ; }
           
        }
        public int SynPrUge
        {
            get { return synPrUge; }
            set { synPrUge = value; }
        }
    }

    class Test { 
    static void Main(string[] args)
    {
            Person p1 = new Person("Jens", "Nyvej 1");
            Mekaniker m1 = new Mekaniker("Otto", "Næsehornsvej 23", 1996, 200);
            Mekaniker m2 = new Mekaniker("Mikkel", "Håndboldvej 55", 2009, 150);
            Værkfører v1 = new Værkfører("Peter", "Savsmuldsvej 23", 2005, 210, 2015, 30);
            Synsmand s1 = new Synsmand("Bent", "Brillevej 20", 1966, 0, 10);

            Console.WriteLine($"{p1.Navn} er en person \n{m1.Navn} er mekaniker \n{m2.Navn} blev svend i {m2.ÅrForSvendeprøve} " +
                $"\n{v1.Navn} er værkfører og bor på {v1.Adresse} \n{s1.Navn} bor på {s1.Adresse}, er synsmand og får {s1.Løn} pr uge ");
            Console.ReadKey();
        }
    }
}


