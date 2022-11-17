using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;
using DAL;

namespace BAL
{
    public class BAL_Bill
    {
        public bool addBill(BEL_Bill bill)
        {
            DAL_Bill addBill = new DAL_Bill();
            return addBill.addBill(bill);
        }
        public int getUnCheckBByTable(int idTable)
        {
            DAL_Bill checkBill = new DAL_Bill();
            return checkBill.getUnCheckBByTable(idTable);
        }
        public bool checkOut(int IDBill,int discount,float totalPrice)
        {
            DAL_Bill checkOut = new DAL_Bill();
            return checkOut.checkOut(IDBill,discount,totalPrice);
        }
        public bool transTable(int table1, int table2)
        {
            DAL_Bill transTable = new DAL_Bill();
            return transTable.transTable(table1, table2);
        }
        public DataTable showBill()
        {
            DAL_Bill show = new DAL_Bill();
            return show.showBill();
        }
        public DataTable statisticsBill(DateTime checkIn, DateTime checkOut)
        {
            DAL_Bill check = new DAL_Bill();
            return check.statisticsBill(checkIn, checkOut);
        }
    }
}
