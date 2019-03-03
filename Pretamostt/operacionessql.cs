using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Pretamostt
{
    class operacionessql
    {
        public string conectar()
        {



            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prestamos; integrated security = true;");
            try
            {
                cnx.Open();
                return "conxion exitosa!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                cnx.Close();
            }



        }

        public string consultasinreaultado(string sql)
        {
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prestamos; integrated security = true;");
            try
            {
                cnx.Open();
                SqlCommand comand = new SqlCommand(sql, cnx);
                comand.ExecuteNonQuery();
                return "";

            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                cnx.Close();
            }
        }
        public DataTable cosnsultaconresultado(string sql)
        {
            SqlDataAdapter ad;
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prestamos; integrated security = true;");
            try
            {
                cnx.Open();

                SqlCommand cmd;
                cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
            }

            catch (SqlException ex)


            {



            }
            cnx.Close();
            return dt;
        }
    }
}
