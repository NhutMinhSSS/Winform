using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BEL
{
    public class BEL_Table
    {
        //private int id;
        private string tableName;
        private string tableStatus;
        private string status;

        public BEL_Table()
        {
            //this.id = 0;
            this.tableName = "Bàn chưa có tên";
            this.tableStatus = "Trống";
            this.status = "True";
        }
        public BEL_Table( string tableName, string tableStatus, string status)
        {
            //this.id = id;
            this.tableName = tableName;
            this.tableStatus = tableStatus;
            this.status = status;
        }
        //public BEL_Table(DataRow dr)
        //{
        //    this.id = (int)dr["ID"];
        //    this.tableName = dr["TABLENAME"].ToString();
        //    this.tableStatus = dr["TABLESTATUS"].ToString();
        //}
        public string TableName
        {
            get { return this.tableName; }
            set { this.tableName = value; }
        }
        public string TableStatus
        {
            get { return this.tableStatus; }
            set { this.tableStatus = value; }
        }
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public static int TableWidth = 90;
        public static int TableHeight = 90;
    }
}
