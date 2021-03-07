using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgaver
{

        class Person : INotifyPropertyChanged
    {
        private string name;
        private double weight;
        private int age;
        private double score;
        private bool accepted;
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged("Name"); } }
        public double Weight { get { return weight; } set { weight = value; NotifyPropertyChanged("Weight"); } }
        public int Age { get { return age; } set { age = value; NotifyPropertyChanged("Age"); } }
        public double Score { get { return score; } set { score = value; NotifyPropertyChanged("Score"); } }
        public bool Accepted { get { return accepted; } set { accepted = value; NotifyPropertyChanged("Accepted"); } }

        public Person(string name2, double weight2, int age2, double score2, bool accepted2)
        {
            this.Name = name2;
            this.Weight = weight2;
            this.Age = age2;
            this.Score = score2;
            this.Accepted = accepted2;
        }

        public Person()
        {

        }

        public override string ToString()
        { 
            return $"{Name} ({Weight} - {Age} - {Score} - {Accepted})";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
