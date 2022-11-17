using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;

namespace BAL
{
    public class BAL_Table
    {
        public DataTable showTable()
        {
            DAL_Table xuLyTable = new DAL_Table();
            return xuLyTable.showTable();
        }
        public DataTable showFoodTable(int idTable)
        {
            DAL_Table xuLyTable = new DAL_Table();
            return xuLyTable.showFoodTable(idTable);
        }
        public string getNameTable(int idTable)
        {
            DAL_Table getName = new DAL_Table();
            return getName.getNameTable(idTable);
        }
        public int getIDTable(string name)
        {
            DAL_Table getID = new DAL_Table();
            return getID.getIDTable(name);
        }
        public bool checkBillInfo(int idBill,int idTable)
        {
            DAL_Table processTable = new DAL_Table();
            return processTable.checkBillInfo(idBill,idTable);
        }
        public bool checkBill(int idTable)
        {
            DAL_Table processTable = new DAL_Table();
            return processTable.checkBill(idTable);
        }
        public bool addTable(BEL_Table table)
        {
            DAL_Table add = new DAL_Table();
            return add.addTable(table);
        }
        public bool updateTable(BEL_Table table, int idTable)
        {
            DAL_Table update = new DAL_Table();
            return update.updateTable(table, idTable);
        }
        public bool deleteTable(int idTable)
        {
            DAL_Table delete = new DAL_Table();
            return delete.deleteTable(idTable);
        }
    }
}
