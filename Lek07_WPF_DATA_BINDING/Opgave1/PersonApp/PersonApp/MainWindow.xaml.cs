using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonApp
{

    public partial class MainWindow : Window
    {
        private Person person;
        public MainWindow() 
        {
        
            InitializeComponent();
            //Person p1 = new Person("Mathias", 80, 24, 99.9, true);
            //PNavn = p1.Name;
            //PWeight = p1.Weight+"";
            //PAge = p1.Age+"";
            //PScore = p1.Score+"";
            //PAccepted = p1.Accepted+"";
            //DataContext = this;

            person = new Person();
            this.DataContext = person;
            
        }

        //public string PNavn { get; set; }
        //public string PWeight { get; set; }
        //public string PAge { get; set; }
        //public string PScore { get; set; }
        //public string PAccepted { get; set; }
     
    }
}
