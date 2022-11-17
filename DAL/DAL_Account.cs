using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEL;

namespace DAL
{
    public class DAL_Account:general
    {
        public DataTable showAccount()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT DISPLAYNAME,USERNAME,TYPE FROM tbACCOUNT";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public bool login(string userName, string password)
        {
            DataTable result = new DataTable();
            string sql = "SELECT * FROM tbACCOUNT WHERE USERNAME LIKE  N'"+userName+"' AND  PASSWORD LIKE N'"+password+"' ";
            result = general.Instance.ExcuteQuery(sql);
            return result.Rows.Count > 0;
        }
        public DataTable showAccoutProFile(string userName, string password)
        {
            DataTable result = new DataTable();
            string sql = "SELECT * FROM tbACCOUNT WHERE USERNAME LIKE  N'" + userName + "' AND  PASSWORD LIKE N'" + password + "' ";
            result = general.Instance.ExcuteQuery(sql);
            return result;
        }
        public bool validateUser(string userName)
        {
            DataTable result = new DataTable();
            string sql = "SELECT * FROM tbACCOUNT WHERE USERNAME LIKE N'" + userName + "'";
            result = general.Instance.ExcuteQuery(sql);
            return result.Rows.Count > 0;
        }
        public bool validatePass(string passWord)
        {
            DataTable result = new DataTable();
            string sql = "SELECT * FROM tbACCOUNT WHERE PASSWORD LIKE N'" + passWord + "'";
            result = general.Instance.ExcuteQuery(sql);
            return result.Rows.Count > 0;
        }
        public BEL_Account getAccountByUserName(string userName)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbACCOUNT where USERNAME = N'" + userName + "'";
            dt = general.Instance.ExcuteQuery(sql);
            foreach (DataRow dr in dt.Rows)
            { 
                return new BEL_Account(dr["DISPLAYNAME"].ToString(), dr["USERNAME"].ToString(),dr["PASSWORD"].ToString(), int.Parse(dr["TYPE"].ToString()));
            }
            return null;
        }
        public int getType(string userName, string passWord)
        {
            string sql = "select * from tbACCOUNT where USERNAME = N'" + userName + "' and PASSWORD = N'" + passWord + "'";
            DataTable dt = new DataTable();
            dt = general.Instance.ExcuteQuery(sql);
            int type;
            if (dt.Rows.Count == 1)
            {
                type = int.Parse(dt.Rows[0]["TYPE"].ToString());
                return type;
            }
            return -1;
           
        }
        public bool updateAccountprofile(BEL_Account acc,string newPassWord)
        {
            string sql = "select * from tbACCOUNT where USERNAME = N'" + acc.UserName + "' and PASSWORD =N'" + acc.PassWord + "'";
            DataTable dt = new DataTable();
            bool result = false;
            dt = general.Instance.ExcuteQuery(sql);
            if(dt.Rows.Count==1)
            {
                string update = "update tbACCOUNT set DISPLAYNAME = N'" + acc.DisPlayName + "', PASSWORD = '"+newPassWord+"' where USERNAME = N'" + acc.UserName + "' and PASSWORD = N'"+acc.PassWord+"'";
                return general.Instance.ExcuteNonQuery(update);
            }
            return result;
        }
        public bool validateACC(string userName)
        {
            bool result = false;
            string sql = "select * from tbACCOUNT where USERNAME = N'" + userName + "'";
            DataTable dt = new DataTable();
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count == 0)
                result = true;
            return result;
        }
        public bool addAccount(BEL_Account acc)
        {
            bool result = false;
            if (validateACC(acc.UserName))
            {
                string sql = "insert into tbACCOUNT (DISPLAYNAME,USERNAME,PASSWORD,TYPE) values (N'" + acc.DisPlayName + "', N'" + acc.UserName + "', N'" + acc.PassWord + "','" + acc.Type + "')";
                result = general.Instance.ExcuteNonQuery(sql);
            }
            return result;
        }
        public bool updateAccount(string displayName, string userName,int type)
        {
            bool result = false;
            string sql = "update tbACCOUNT set DISPLAYNAME = N'" + displayName + "', TYPE = '" + type + "' where USERNAME = N'" + userName + "'";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public bool deleteAccount(string userName)
        {
            bool result = false;
            string sql = "delete from tbACCOUNT where USERNAME = N'" + userName + "'";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public bool resetPass(string userName)
        {
            Encryption encry = new Encryption();
            bool result = false;
            string sql = "update tbACCOUNT set PASSWORD = N'"+encry.Encrypt("0",true)+"' where USERNAME = N'" + userName + "' ";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
    }
}
