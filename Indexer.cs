using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    
        class ParentClass
        {
            private string[] range = new string[5];
            public string this[int indexrange]
            {
                get
                {
                    return range[indexrange];
                }
                set
                {
                    range[indexrange] = value;
                }
            }
        }
        /* The Above Class just act as array declaration using this pointer */
        class childclass
        {
            public static void Main()
            {
                ParentClass obj = new ParentClass();
                /* The Above Class ParentClass  create one object name is obj */
                obj[0] = "ONE";
                obj[1] = "TWO";
                obj[2] = "THREE";
                obj[3] = "FOUR ";
                obj[4] = "FIVE";
                Console.WriteLine("WELCOME TO C# CORNER HOME PAGE\n");
                Console.WriteLine("\n");
                Console.WriteLine("{0}\n,{1}\n,{2}\n,{3}\n,{4}\n", obj[0], obj[1], obj[2], obj[3], obj[4]);
                Console.WriteLine("\n");
                Console.WriteLine("shweta\n");
                Console.WriteLine("\n");
                Console.ReadLine();
            }
        }
    }

