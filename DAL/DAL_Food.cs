using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Food:general
    {
        public DataTable showFood()
        {
            DataTable dt = new DataTable();
            string sql = "Select F.ID,F.FNAME,FC.FCNAME,F.PRICE from tbFOOD F,tbFOODCATEGORY FC where F.STATUS = 'True' and FC.STATUS = 'True' and F.IDCATEGORY = FC.ID";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public DataTable loadFood(int idCategory)
        {
            DataTable dt = new DataTable();
            string sql = "Select * from tbFOOD where IDCATEGORY = '" + idCategory + "' and STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public int getID(string FName)
        {
            DataTable dt = new DataTable();
            string sql = "Select * from tbFood where FNAME = N'" + FName + "' and STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            int result;
            if (dt.Rows.Count == 0)
                result = -1;
            else
                result = int.Parse(dt.Rows[0]["ID"].ToString());
            return result;
        }
        public bool validateFoodName(string foodName)
        {
            bool result = true;
            DataTable dt = new DataTable();
            string sql = "select * from tbFOOD where FNAME = N'" + foodName + "' and STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count > 0)
                result = false;
            return result;
        }
        public bool addFood(BEL_Food food)
        {
            bool result = false;
            if (validateFoodName(food.FoodName))
            {
                string sql = "insert into tbFOOD(FNAME,IDCATEGORY,PRICE,STATUS) values (N'" + food.FoodName + "','" + food.IDCategory + "','" + food.Price + "','" + food.Status + "')";
                result = general.Instance.ExcuteNonQuery(sql);
            }
            return result;
        }
        public bool updateFood(BEL_Food food, int idFood)
        {
            bool result = false;
                string sql = "update tbFOOD set FNAME = N'" + food.FoodName + "', IDCATEGORY = '" + food.IDCategory + "', PRICE = '" + food.Price + "', STATUS = '" + food.Status + "' where ID = '" + idFood + "'";
                result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public bool deleteFood(int idFood)
        {
            bool result = false;
            string sql = "update tbFOOD set STATUS = 'False' where ID = '" + idFood + "'";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public DataTable searchFood(string nameFood)
        {
            DataTable dt = new DataTable();
            string sql = "Select F.ID,F.FNAME,FC.FCNAME,F.PRICE from tbFOOD F,tbFOODCATEGORY FC where F.STATUS = 'True' and FC.STATUS = 'True' and F.IDCATEGORY = FC.ID and F.FNAME like N'%" + nameFood + "%'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
    }
}
