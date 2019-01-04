using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DATABASEPROJECT
{
    class DATA
    {

        static void Main(string[] args)
        {

            using (SqlConnection con = new SqlConnection())
            {


                //step1
                //con.ConnectionString = "Server = WKSBAN24KAN0008\\SQLEXPRESS ;Database = MyDB;Integrated Security = true";
                con.ConnectionString = "Data Source=WKSBAN24KAN0008\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";
                con.Open();

                ///STEP 2:


                string query = "select * from Employee";

                using (SqlDataAdapter adap = new SqlDataAdapter(query, con))
                {

                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    try
                    {
                        Console.WriteLine("enter id");
                        int id = Convert.ToInt32(Console.ReadLine());
                       

                        DataView dv = new DataView();
                        dv.Table = ds.Tables[0];

                       // dv.RowFilter = "name like s%";
                        dv.RowFilter = "employee_id= " + id;
                        Console.WriteLine("{0} {1} {2} {3}", dv[0][0], dv[0][1], dv[0][2], dv[0][3]);
                    }
                    catch (Exception IO)
                    {
                        Console.WriteLine(IO.Message);
                    }
                    
                    DataTable dt = ds.Tables["Employee"];

                    ////using (SqlCommand cmd = new SqlCommand(query, con))
                    ////{
                    ////    Console.WriteLine("enter the id ");
                    ////int id = Convert.ToInt32(Console.ReadLine());
                    ////cmd.Parameters.AddWithValue("@id", id);

                    ////////   //this is third type cmd.Parameters.Add(new SqlParameter("@id",SqlDbType.Int));
                    ////////    //cmd.Parameters["@id"].Value = id;

                    //////// //  this is second way //cmd.Parameters.Add(new SqlParameter("@id", id));
                    ////////    /////STEP 3:

                    ////SqlDataReader sdr = cmd.ExecuteReader();
                    ////sdr.Read();

                    //Console.WriteLine("{0} {1} {2} {3}", r[0], sdr[1], sdr[2], sdr[3]);

                }

                    Console.ReadLine();
                }
            }
        }
    }

