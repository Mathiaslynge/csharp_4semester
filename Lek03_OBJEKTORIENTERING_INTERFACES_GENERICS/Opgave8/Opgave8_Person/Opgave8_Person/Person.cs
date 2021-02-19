using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave8_Person
{
    class Person
    {
        private String Name { get; set; }
        private int Age { get; set; }
        private double Weight { get; set; }
        private String NameAgeWeight { get; set; }

        public Person(String name, int age, double weight)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
        }

        public Person(String nameAgeWeight)
        {
            String[] list = nameAgeWeight.Split(';');
            int tempAge;
            double tempWeight;
            if (Int32.TryParse(list[1], out tempAge) && Double.TryParse(list[2], out tempWeight))
            {
                Name = list[0];
                Age = tempAge;
                Weight = tempWeight;
            } else
            {
                throw new ArgumentException(String.Format("String skal være i formatet 'name;age;weight'"));
            }
           
        }

        public override string ToString()
        {
            return string.Format($"{Name,-10}- {Age,-4}- {Weight,-4}", "ColumnA", "ColumnB", "ColumnC");

        }
    }
}
