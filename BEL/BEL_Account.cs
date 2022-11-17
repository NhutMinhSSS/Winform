using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Account
    {
        private String disPlayName;
        private string userName;
        private string passWord;
        private int type;
        //private string status;

        public BEL_Account()
        {
            this.disPlayName = "ADMIN";
            this.userName = null;
            this.passWord = "0";
            this.type = 0;
            //this.status = "True";
        }
        public BEL_Account(string displayName, string userName, string passWord, int type)
        {
            this.disPlayName = displayName;
            this.userName = userName;
            this.passWord = passWord;
            this.type = type;
            //this.status = status;
        }
        public string DisPlayName
        {
            get { return this.disPlayName; }
            set { this.disPlayName = value; }
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        public string PassWord
        {
            get { return this.passWord; }
            set { this.passWord = value; }
        }
        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
