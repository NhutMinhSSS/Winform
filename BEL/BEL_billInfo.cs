using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_billInfo
    {
        private int idBill;
        private int idFood;
        private int countBill;
        private string status;

        public BEL_billInfo()
        {
            this.idBill = 0;
            this.idFood = 0;
            this.countBill = 0;
            this.status = "True";
        }
        public BEL_billInfo(int idBill, int idFood, int countBill, string status)
        {
            this.idBill = idBill;
            this.idFood = idFood;
            this.countBill = countBill;
            this.status = status;
        }
        public int IDBill
        {
            get { return this.idBill; }
            set { this.idBill = value; }
        }
        public int IDFood
        {
            get { return this.idFood; }
            set { this.idFood = value; }
        }
        public int CountBill
        {
            get {return this.countBill; }
            set { this.countBill = value; }
        }
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
