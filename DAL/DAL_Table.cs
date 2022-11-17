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
    public class DAL_Table:general
    {
        public DataTable showTable()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT ID, TABLENAME, TABLESTATUS FROM tbTABLE WHERE STATUS = 'True'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public DataTable showFoodTable(int idTable)
        {
            DataTable dt = new DataTable();
            string sql = "select tbFOOD.FNAME,tbBILLINFO.COUNTBILL,tbFOOD.PRICE, tbFOOD.PRICE*tbBILLINFO.COUNTBILL from tbBILL,tbBILLINFO,tbFOOD where tbBILL.ID = tbBILLINFO.IDBILL and tbBILLINFO.IDFOOD = tbFOOD.ID and tbBILL.BILLSTATUS = 0 and tbBILL.IDTABLE = '" + idTable + "'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public string getNameTable(int idTable)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbTABLE where ID = '" + idTable + "'";
            dt = general.Instance.ExcuteQuery(sql);
            return dt.Rows[0]["TABLENAME"].ToString();
        }
        public int getIDTable(string name)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbTABLE where TABLENAME = N'" + name + "'";
            dt = general.Instance.ExcuteQuery(sql);
            int result = int.Parse(dt.Rows[0]["ID"].ToString());
            return result;
        }
        public bool checkBillInfo(int idBill,int idTable)
        {
            bool result = false;
            string sql = "select * from tbBILL where ID = '" + idBill + "' and BILLSTATUS = 0";
            DataTable dt = new DataTable();
            dt = general.Instance.ExcuteQuery(sql);
            string sqlkt = "select * from tbBILLINFO where IDBILL = '"+idBill+"'";
           
            DataTable dt1 = new DataTable();
           
            dt1 = general.Instance.ExcuteQuery(sqlkt);
            int i = int.Parse(dt1.Rows.Count.ToString());
            if (i > 0)
            {
                if (dt.Rows.Count > 0)
                    idTable = int.Parse(dt.Rows[0]["IDTABLE"].ToString());
                string update = "update tbTABLE set TABLESTATUS = N'Có người' where ID = '" + idTable + "'";
                result = general.Instance.ExcuteNonQuery(update);
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    string update = "update tbTABLE set TABLESTATUS = N'Có người' where ID = '" + idTable + "'";
                    result = general.Instance.ExcuteNonQuery(update);
                }
                else
                    checkBill(idTable);
            }
            return result;
        }
        public bool checkBill (int idTable)
        {
            string update = "update tbTABLE set TABLESTATUS = N'Trống' where ID = '" + idTable + "'";
            bool result = general.Instance.ExcuteNonQuery(update);
            return result;
        }
        public bool validateTable(string tableName)
        {
            bool result = true;
            string sql = "select * from tbTABLE where TABLENAME = N'"+tableName+"' and STATUS = 'True'";
            DataTable dt = new DataTable();
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count > 0)
                result = false;
            return result;
        }
        public bool addTable(BEL_Table table)
        {
            bool result = false;
            if (validateTable(table.TableName))
            {
                string sql = "insert into tbTABLE(TABLENAME,TABLESTATUS,STATUS) values (N'" + table.TableName + "',N'" + table.TableStatus + "','" + table.Status + "')";
                result = general.Instance.ExcuteNonQuery(sql);
            }
            return result;
        }
        public bool updateTable(BEL_Table table, int idTable)
        {
            bool result = false;
                string sql = "update tbTABLE set TABLENAME = N'" + table.TableName + "', TABLESTATUS = N'" + table.TableStatus + "', STATUS = '" + table.Status + "' where ID = '" + idTable + "'";
                result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
        public bool deleteTable(int idTable)
        {
            bool result = false;
            string sql = "update tbTable set STATUS = 'False' where ID = '" + idTable + "' and TABLESTATUS = N'Trống'";
            result = general.Instance.ExcuteNonQuery(sql);
            return result;
        }
    }
}
