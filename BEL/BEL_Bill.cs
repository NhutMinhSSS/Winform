using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Bill
    {
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int idTable;
        private int billStatus;
        //private string status;
        private int discount;

        public BEL_Bill()
        {
            this.dateCheckIn = System.DateTime.Now;
            this.dateCheckOut=null;
            this.idTable = 0;
            this.billStatus = 0;
            //this.status = "True";
            this.discount = 0;
        }
        public BEL_Bill(DateTime? dateCheckIn, DateTime? dateCheckOut, int idTable, int billStatus,int discount)
        {
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.idTable = idTable;
            this.billStatus = billStatus;
            //this.status = status;
            this.discount = discount;
        }
        public DateTime? DateCheckIn
        {
            get { return this.dateCheckIn; }
            set { this.dateCheckIn = value; }
        }
        public DateTime? DateCheckOut
        {
            get { return this.dateCheckOut; }
            set { this.dateCheckOut = value; }
        }
        public int IDTable
        {
            get { return this.idTable; }
            set { this.idTable = value; }
        }
        public int BillStatus
        {
            get { return this.billStatus; }
            set { this.billStatus = value; }
        }
        //public string Status
        //{
        //    get { return this.status; }
        //    set { this.status = value; }
        //}
        public int Discount
        {
            get { return this.discount; }
            set { this.discount = value; }
        }
    }
}
