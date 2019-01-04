using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEPROJECT
{
    class Employee2
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        string query;
        SqlCommandBuilder scb;

        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public int  manager_id { get; set; }
      
        public string Designation { get; set; }


        public Employee2()
        {
            con = new SqlConnection("Data Source=WKSBAN24KAN0008\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            con.Open();
            query = "select * from Employee";
            adap = new SqlDataAdapter(query, con);
            ds = new DataSet();
          
            scb = new SqlCommandBuilder(adap);
            adap.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adap.Fill(ds);
        }


        public void Display()
        {
            DataTable dt = ds.Tables[0];
            foreach (DataRow r in dt.AsEnumerable())
            {
                Console.WriteLine("{0},{1},{2},{3}", r[0], r[1], r[2], r[3]);
            }

        }

        public void DisplayByID()
        {
            Console.WriteLine("Enter id");
             employee_id = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(employee_id);

            Console.WriteLine("{0},{1},{2},{3}", dr[0], dr[1], dr[2], dr[3]);


        }


        public void Insert()
        {
            Console.WriteLine("enter empid:");
            employee_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter name:");
            employee_name= Console.ReadLine();
           
            Console.WriteLine("enter designation:");
            Designation = Console.ReadLine();
            Console.WriteLine("enter manager id");
            manager_id = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = employee_id;
            dr[1] = employee_name;
            dr[2] = Designation;
            dr[3] = manager_id;
           
            dt.Rows.Add(dr);

            adap.Update(ds);
  

        }

        public void Update()
        {
            Console.WriteLine("enter empid:");
            employee_id= Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(employee_id);

            Console.WriteLine("enter name:");
            employee_name = Console.ReadLine();
            
            Console.WriteLine("enter designation:");
            Designation = Console.ReadLine();

            Console.WriteLine("enter manager id");
            manager_id =Convert.ToInt32( Console.ReadLine());

            dr.BeginEdit();
           
            dr[1] = employee_name;
            dr[2] = Designation;
            dr[3] = manager_id;

           // dt.Rows.Add(dr);
            dr.EndEdit();


            adap.Update(ds);
            adap.Fill(ds);




        }


        public void Delete()
        {
            Console.WriteLine("enter empid:");
            employee_id = Convert.ToInt32(Console.ReadLine());

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows.Find(employee_id);

            dt.Rows.Remove(dr);



            adap.Update(ds);
            adap.Fill(ds);




        }

    }
}

