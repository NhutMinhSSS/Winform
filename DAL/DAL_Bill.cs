using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;

namespace DAL
{
    public class DAL_Bill:general
    {
        public int getUnCheckBByTable(int idTable)
        {
            DataTable dt = new DataTable();
            string sql = "select * from tbBILL where IDTABLE = '" + idTable + "' and BILLSTATUS = 0";
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                int result = int.Parse(dt.Rows[0]["ID"].ToString());
                return result;
            }
            else
                return -1;
        }
        public bool addBill(BEL_Bill bill)
        {
            string sql = "insert into tbBill (IDTABLE) values ('" + bill.IDTable + "') ";
            return general.Instance.ExcuteNonQuery(sql);
        }
        public bool checkOut(int IDBill, int discount, float totalprice)
        {
            string sql = "update tbBILL set DATECHECKOUT = GETDATE(), BILLSTATUS = 1, " + "DISCOUNT = " + discount + ", TOTALPRICE = " + totalprice + " where ID = '" + IDBill + "'";
            return general.Instance.ExcuteNonQuery(sql);
        }
        public int getBillID(int table)
        {
            DataTable dt = new DataTable();
            int idBill = 0;
            string sql = "select * from tbBILL where IDTABLE = '" + table + "' and BILLSTATUS = 0";
            dt = general.Instance.ExcuteQuery(sql);
            if (dt.Rows.Count > 0)
                idBill = int.Parse(dt.Rows[0]["ID"].ToString());
            else
            {
                BEL_Bill bill = new BEL_Bill(System.DateTime.Now, null, table, 0, 0);
                addBill(bill);
                dt = general.Instance.ExcuteQuery(sql);
                idBill = int.Parse(dt.Rows[0]["ID"].ToString());
            }
            return idBill;
        }
        public bool transBill(int idFirst, int idSecond)
        {
            DataTable dt = new DataTable();
            bool result1 = false;
            bool result2 = false;
            DataTable kt1 = new DataTable();
            DataTable kt2 = new DataTable();
            kt1 = general.Instance.ExcuteQuery("select * from tbBILLINFO where IDBILL = '" + idSecond + "'");
            kt2 = general.Instance.ExcuteQuery("select * from tbBILLINFO where IDBILL = '" + idFirst + "'");
            if (kt1.Rows.Count > 0 && kt2.Rows.Count>0)
                return false;
            string sql = "select ID into IDBILLINFOTABLE from tbBILLINFO where IDBILL = '" + idSecond + "'";
            dt = general.Instance.ExcuteQuery(sql);
            string update1 = "update tbBILLINFO set IDBILL = '" + idSecond + "' where IDBILL = '" + idFirst + "'";
            result1= general.Instance.ExcuteNonQuery(update1);
            string update2 = "update tbBILLINFO set IDBILL = '" + idFirst + "' where ID in (select * from IDBILLINFOTABLE)";
            result2 = general.Instance.ExcuteNonQuery(update2);
            string drop = "drop table IDBILLINFOTABLE";
            general.Instance.ExcuteNonQuery(drop);
            if (result1 || result2)
                return true;
            return false;

        }
        public bool transTable(int table1, int table2)
        {
            bool result = false;
            int idBillFist = 0, idBillSecond = 0 ;
            idBillFist = getBillID(table1);
            idBillSecond = getBillID(table2);
            result = transBill(idBillFist, idBillSecond);
            return result;
        }
        public DataTable showBill()
        {
            DataTable dt = new DataTable();
            string sql = "select tbTABLE.TABLENAME as [Tên bàn],tbBILL.TOTALPRICE as [Tổng tiền],DATECHECKIN as [Ngày đặt],tbBILL.DATECHECKOUT as [Ngày thanh toán],tbBILL.DISCOUNT as [Giảm giá] " +
                        "from tbBILL, tbTABLE " +
                        "where tbBILL.BILLSTATUS = 1 and tbBILL.IDTABLE = tbTABLE.ID";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
        public DataTable statisticsBill(DateTime checkIn, DateTime checkOut)
        {
            DataTable dt = new DataTable();
            string sql = "select tbTABLE.TABLENAME as [Tên bàn],tbBILL.TOTALPRICE as [Tổng tiền],DATECHECKIN as [Ngày đặt],tbBILL.DATECHECKOUT as [Ngày thanh toán],tbBILL.DISCOUNT as [Giảm giá] " +
                        "from tbBILL, tbTABLE " +
                        "where tbBILL.DATECHECKIN >='" + checkIn + "'" +
                        "and tbBILL.DATECHECKOUT <='" + checkOut + "' " +
                        "and tbBILL.BILLSTATUS = 1 and tbBILL.IDTABLE = tbTABLE.ID";
            dt = general.Instance.ExcuteQuery(sql);
            return dt;
        }
    }
}
