using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ATTRIBUTEproject
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public DateTime DoB { get; set; }

        public string Department { get; set; }

        public int Salary { get; set; }

        [NonSerialized]
        public string additionalInfo;


        public void SerializeEmployee()
        {
            Employee emp = new Employee()
            {
                Name = "Samatha",
                Phone = "1234567890",
                DoB = Convert.ToDateTime("02-10-1976"),
                Department = "Pschycology",
                Salary = 343434,
                additionalInfo = "We don't want it to serialize"
            };

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsout = new FileStream("employee.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, emp);
                    Console.WriteLine("Object Serialized");
                }
            }
            catch
            {
                Console.WriteLine("An error has occured");
            }
        }

        public void DeserializeEmployee()
        {
            Employee emp = new Employee();

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream("employee.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    emp = (Employee)bf.Deserialize(fsin);
                    Console.WriteLine("Object Deserialized");

                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", emp.Name, emp.Phone, emp.DoB, emp.Department, emp.Salary.ToString());
                }
            }
            catch
            {
                Console.WriteLine("An error has occured",emp.additionalInfo);
            }
        }

    }
}


namespace ATTRIBUTEproject

{

    class Class2

    {

        static void Main(string[] args)

        {

            Employee e1 = new Employee();

            e1.SerializeEmployee();

            e1.DeserializeEmployee();

            Console.ReadLine();
        }
    }
}





