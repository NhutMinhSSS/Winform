using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;

namespace DAL
{
    public class DAL_BillInfo:general
    {
        public bool addBillInfo(BEL_billInfo billInfo)
        {
            if (billInfo.CountBill > 0)
            {
                string sql = "insert into tbBILLINFO values ('" + billInfo.IDBill + "','" + billInfo.IDFood + "','" + billInfo.CountBill + "','" + billInfo.Status + "')";
                return general.Instance.ExcuteNonQuery(sql);
            }
            return false;
        }
        public bool addBillInfoExits(BEL_billInfo billInfo,int count)
        {
            string sql = null;
                DataTable dt = general.Instance.ExcuteQuery("Select * from tbBILLINFO where IDFOOD = '" + billInfo.IDFood + "' and IDBILL = '" + billInfo.IDBill + "'");
            if (dt.Rows.Count > 0)
            {
                count += int.Parse(dt.Rows[0]["COUNTBILL"].ToString());
                if (count > 0)
                {
                    sql = "UPDATE tbBILLINFO set COUNTBILL += '" + billInfo.CountBill + "' Where IDFOOD = '" + billInfo.IDFood + "' and IDBILL = '" + billInfo.IDBill + "'";
                }
                else
                {
                    sql = "delete from tbBILLINFO where IDFOOD = '" + billInfo.IDFood + "' and IDBILL = '" + billInfo.IDBill + "' ";
                }
                return general.Instance.ExcuteNonQuery(sql);
            }
            return addBillInfo(billInfo);
        }
    }
}
