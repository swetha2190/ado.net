using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
   public static class ClassMethod
    {
        private static int fact;

        static void Main(string[] args)
        {

            int num = 10;
            int result = num.Factorial();
            Console.WriteLine("factorial is {0}", result);
            Console.ReadLine();
        }
    }

    public static class class2
    {
        public static int Factorial(this int n)
        {
            int fact = 1;
         
           while(n!=1)
            {
                fact = fact * n;
                n--;
          
            }
            return fact;
        }
    }
}
