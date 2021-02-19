using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOpgave
{
    struct Time
    {
        private int secondsSinceMidnight;
        private int hour;
        private int minutes;
        private int seconds;


        public Time(String cTime)
        {
            if (cTime.Length == 8) { 
            string[] subs = cTime.Split(':');
    
            hour = Int32.Parse(subs[0]);
            minutes = Int32.Parse(subs[1]);
            seconds = Int32.Parse(subs[2]);
            secondsSinceMidnight = (hour * 3600) + (minutes * 60) + seconds;
            } else
            {
                throw new ArgumentException(String.Format("Must be hh:mm:ss"));
            }
        }

        public Time(int hour, int minutes, int seconds)
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
            secondsSinceMidnight = (hour * 3600) + (minutes * 60) + seconds;
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public override string ToString()
        {
            return hour+":"+minutes+":"+seconds;
        }

    }



    class Test
    {
        static void Main(string[] args)
        {
            Time t1, t2;
            t1 = new Time("08:30:00");
            t2 = t1;
            t2.Hour = t2.Hour + 2;
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
            Console.ReadKey();
        }
    }
}



    