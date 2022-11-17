using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;

namespace DAL
{
    public class DAL_FoodCategory: general
    {
        public DataTable loadCategory()
        {
            DataTable dt = new DataTable();
            string sql = "Select ID,FCNAME from tbFOODCATEGORY where STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public int getIDCategory(string FCName)
        {
            DataTable dt = new DataTable();
            string sql = "select ID from tbFOODCATEGORY where FCNAME = N'" + FCName + "' and STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            int result = int.Parse(dt.Rows[0]["ID"].ToString());
            return result;
        }
        public bool validateCategory(string categoryName)
        {
            bool result = true;
            string sql = "slect * from tbFOODCATEGORY where FCNAME = N'" + categoryName + "' where STATUS = 'True'";
            DataTable dt = new DataTable();
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count > 0)
                result = false;
            return result;
        }
        public bool addCategory(BEL_FoodCategory category)
        {
            bool result = false;
            if (validateCategory(category.FoodCName))
            {
                string sql = "insert into tbFOODCATEGORY (FCNAME,STATUS) values (N'" + category.FoodCName + "','" + category.Status + "')";
                result = general.Instance.ExcuteNonQuery(sql);
            }
            return result;
        }
        public bool updateCategory(BEL_FoodCategory category, int ID)
        {
            bool result = false;
                string sql = "update tbFOODCATEGORY set FCNAME = N'" + category.FoodCName + "', STATUS = '" + category.Status + "' where ID = '" + ID + "'";
                result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public bool deleteCategory(int ID)
        {
            bool result = false;
            string sql = "update tbFOODCATEGORY set STATUS = 'False' where ID = '" + ID + "'";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
    }
}
