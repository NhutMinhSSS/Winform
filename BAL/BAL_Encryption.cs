using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
   public class BAL_Encryption
    {
        public string encryption(string passWord)
        { 
            Encryption encry = new Encryption();
            return encry.Encrypt(passWord, true);
        }
    }
}
