using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class general
    {
        public SqlConnection conn = new SqlConnection(@"Data source = NhutMinhSSS\SQLEXPRESS;Initial catalog=QuanLyQuanCafe ;Integrated security=True");
        private static general instance;
        public static general Instance
        {
            get { if (instance == null)
                    instance = new general();
                return general.instance;
            }
            private set { general.instance = value; }
        }
        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch(Exception err)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool ExcuteNonQuery(string query)
        {
            bool result = false;
            try
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }
            catch(Exception err)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
