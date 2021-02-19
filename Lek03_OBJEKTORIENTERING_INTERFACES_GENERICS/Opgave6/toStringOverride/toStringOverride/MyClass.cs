using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toStringOverride
{
    class MyClass
    {
        private int EnInteger { get; set; }

        public MyClass(int integeren)
        {
            this.EnInteger = integeren;
        }

        public override string ToString()
        {
            return EnInteger+"";
        }
        static void Main(string[] args)
        {
            MyClass mc = new MyClass(32);
            Console.WriteLine(mc.ToString());
            Console.ReadKey();
        }
    }
}
