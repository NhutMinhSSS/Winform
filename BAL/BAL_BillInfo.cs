using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using DAL;

namespace BAL
{
    public class BAL_BillInfo
    {
        public bool addBillInfo(BEL_billInfo billInfo)
        {
            DAL_BillInfo addBillInfo = new DAL_BillInfo();
            return addBillInfo.addBillInfo(billInfo);
        }
        public bool addBillInfoExits(BEL_billInfo billInfo, int count)
        {
            DAL_BillInfo addBExits = new DAL_BillInfo();
            return addBExits.addBillInfoExits(billInfo,count);
        }
    }
}
