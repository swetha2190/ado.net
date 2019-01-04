using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DATABASEPROJECT
{
    class BACKend
    {
        public static void Main(string[] args)
        {
            Employee2 e = new Employee2();
           
            char ch = 'y';
            int c;
            do
            {
                Console.WriteLine("select your choice\n");
                Console.WriteLine("1.Insert\n 2.Update\n  3.Delete\n 4.Display By empId\n 5.Display");
                c = Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 5:
                        e.Display();
                        break;
                    case 4:
                        e.DisplayByID();
                        break;
                    case 1:

                        e.Insert();
                        break;
                    case 2:
                        e.Update();
                        break;
                    case 3:
                        e.Delete();
                        break;
                    default: break;
                }

                Console.WriteLine("do you wish to continue? yes or no?");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'y');

            Console.ReadLine();
            

        }
    }
}
