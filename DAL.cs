using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace register
{
    class DAL
    {

        SqlConnection con;
        public SqlCommand com;
        SqlDataAdapter da;
        public SqlDataReader dr;
        //string username, password;
        public DAL()
        {

            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-NEK3N6E;Initial Catalog=assignment3;Integrated Security=True ";
            com = new SqlCommand();
            da = new SqlDataAdapter();
            com.Connection = con;
            da.SelectCommand = com;


        }
        public void EXE(string SQL, String[] paramsArray, String[] valuesArray)
        {//waitr

            com.Connection = con;
            com.CommandText = SQL;
            for (int i = 0; i < paramsArray.Length; i++)
            {
                com.Parameters.AddWithValue(paramsArray[i], valuesArray[i]);
            }
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        
        public DataTable Select(string SQL)
        {

            com.CommandText = SQL;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return (dt);


        }
        public void connect()
        {

            con.ConnectionString = @"Data Source=DESKTOP-NEK3N6E;Initial Catalog=assignment3;Integrated Security=True ";
            con.Open();


        }
        public void disconnect()
        {

            con.Close();

        }

       

    }
}
