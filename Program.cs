using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DATABASEPROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "Server = WKSBAN24KAN0008\\SQLEXPRESS ;Database = MyDB;Integrated Security = true";
            con.ConnectionString = "Data Source=WKSBAN24KAN0008\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";
            con.Open();

            string query = "select * from Employee";

            SqlCommand cmd = new SqlCommand(query,con);

            

            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}",sdr[0],sdr[1],sdr[2],sdr[3]);
            }
            Console.ReadLine();
        }
    }
}



