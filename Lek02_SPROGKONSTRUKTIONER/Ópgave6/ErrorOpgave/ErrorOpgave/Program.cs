using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorOpgave
{
    class Program
    {


        private void MyMethodWithError(int num = 0)
        {
            throw new Exception();
        }

        public void MyNormalMethod(int num = 0)
        {
            try
            {
                MyMethodWithError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Exception fanget");
            }
            finally
            {
                Console.WriteLine("VI ER I FINALLY NU");
            }
        }

        static void Main(string[] args)
        {
            Program p1 = new Program();
            p1.MyNormalMethod();
            Console.ReadKey();
        }
    }
}
