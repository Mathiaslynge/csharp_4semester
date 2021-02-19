using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave10
{
    class Person : IComparable<Person>
    {
        public Person(string s)
        {
            string[] person = s.Split(';');
            Name = person[0];
            Age = Int32.Parse(person[1]);
            Weight = Int32.Parse(person[2]);
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("Name: {0,-2} - Age:{1,-2} - Weight:{2, 2}KG", Name, Age, Weight);
        }
    }
}