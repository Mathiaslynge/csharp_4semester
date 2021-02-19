using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave7MyClass
{
    class MyClass
    {
        public int Arg { set; get; }

        public MyClass(int arg)
        {
            this.Arg = arg;
        }

        public override string ToString()
        {
            return "Arg set to " + Arg;
        }
            
        static void Main(string[] args)
        {

            MyClass mc = new MyClass(56);
            Console.WriteLine(mc);
            mc.Arg = 65;
            Console.WriteLine(mc);
            Console.ReadKey();
        }
    }
}
