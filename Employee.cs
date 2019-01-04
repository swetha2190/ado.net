using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEPROJECT
{
    class Employee
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;

        public int employee_id { get; set; }

        public String  employee_name { get; set; }
        public String designation{ get; set; }
        public int manager_id { get; set; }

        public Employee()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=WKSBAN24KAN0008\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";
            con.Open();
        }
        public void insert()
        {
            string query = "insert into employee values(@employee_id,@employee_name,@designation,@manager_id)";
            // string query = "insert into Employee3 values(@Id,@Name,@Department,@Designation,@Salary)";
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";
            cmd.Connection = con;
            cmd = new SqlCommand(query, con);

            Console.WriteLine("enter id");
            employee_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@employee_id", employee_id);


            Console.WriteLine("enter employee name");
            employee_name = Console.ReadLine();
            cmd.Parameters.AddWithValue("@employee_name", employee_name);


            Console.WriteLine("enter employee designation");
            designation = Console.ReadLine();
            cmd.Parameters.AddWithValue("@designation", designation);


            Console.WriteLine("enter manager m_id");
            manager_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@manager_id", manager_id);

            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("one row inserted");
        }

        public void update()
        {
            string query = "update employee set employee_id = @employee_id,employee_name =@employee_name ,designation = @designation where manager_id = @manager_id";
            cmd = new SqlCommand(query, con);

            Console.WriteLine("enter id");
            employee_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@employee_id", employee_id);


            Console.WriteLine("enter employee name");
            employee_name = Console.ReadLine();
            cmd.Parameters.AddWithValue("@employee_name", employee_name);


            Console.WriteLine("enter employee designation");
            designation = Console.ReadLine();
            cmd.Parameters.AddWithValue("@designation", designation);


            Console.WriteLine("enter manager m_id");
            manager_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@manager_id", manager_id);

            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("one row updated");
        }


        public void delete()
        {
            string query = "delete from employee where employee_id = @employee_id";
            cmd = new SqlCommand(query, con);

            Console.WriteLine("enter id");
            employee_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@employee_id", employee_id);


            Console.WriteLine("enter employee name");
            employee_name = Console.ReadLine();
            cmd.Parameters.AddWithValue("@employee_name", employee_name);


            Console.WriteLine("enter employee designation");
            designation = Console.ReadLine();
            cmd.Parameters.AddWithValue("@designation", designation);


            Console.WriteLine("enter manager m_id");
            manager_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@manager_id", manager_id);

            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("one row deleted");
        }

        public void Display_By_empId()
        {
            string query = "select * from Employee where employee_id = @employee_id";
            cmd = new SqlCommand(query, con);

            Console.WriteLine("enter id");
             employee_id = Convert.ToInt32(Console.ReadLine());
             cmd.Parameters.AddWithValue("@employee_id", employee_id);

            sdr = cmd.ExecuteReader();
            sdr.Read();
           
                Console.WriteLine("{0} {1} {2} {3}", sdr[0], sdr[1], sdr[2], sdr[3]);
            

            // int i = cmd.ExecuteNonQuery();
            Console.WriteLine("table displayed with all columns");
        }
        public void Display()
        {
            string query = "select * from Employee";
            cmd = new SqlCommand(query, con);

            sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", sdr[0], sdr[1], sdr[2], sdr[3]);
            }

           // int i = cmd.ExecuteNonQuery();
            Console.WriteLine("table displayed with all columns");
        }


    }
}
