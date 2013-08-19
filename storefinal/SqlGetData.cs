using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace storefinal
{
    /// <summary>
    /// This is related to the Database access from the application
    /// </summary>
    class SqlGetData
    {
        static SqlConnection con;
        static SqlDataAdapter adapt;
        static DataSet ds;
        static SqlCommand sqlcmd;
        static DataTable dt;

        public void StoreFinal(){
            // Class needs constructor
        }

        public static SqlConnection GetConnection()
        {
            con = new SqlConnection("server=RONISH-PC\\NEW; uid=sa; pwd=ronish; database=store");
            return con;
        }

        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }

        }

        public DataTable GetData(string query)
        {
            try
            {
                sqlcmd = new SqlCommand(query, GetConnection());
                adapt = new SqlDataAdapter(sqlcmd);
                dt = new DataTable();
                adapt.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
                
            }
            return dt;
        }
        
        public static bool InsertData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void QryCommand(string query)
        {
            try
            {
               SqlConnection con= GetConnection();
                con.Open();
                sqlcmd = new SqlCommand(query, con);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
            
        }
    }
}
