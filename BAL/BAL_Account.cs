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
    public class BAL_Account
    {
        public DataTable ShowAccount()
        {
            DAL_Account showAccount = new DAL_Account();
            return showAccount.showAccount();
        }
        public DataTable showAccountProFile(string userName, string passWord)
        {
            DAL_Account processA = new DAL_Account();
            return processA.showAccoutProFile(userName, passWord);
        }
        public bool login(string userName, string passWord)
        {
            DAL_Account Login = new DAL_Account();
            return Login.login(userName, passWord);
        }
        public bool validateUser(string userName)
        {
            DAL_Account xuLyUser = new DAL_Account();
            return xuLyUser.validateUser(userName);
        }
        public bool validatePass(string passWord)
        {
            DAL_Account xuLyUser = new DAL_Account();
            return xuLyUser.validatePass(passWord);
        }
        public BEL_Account getAccountByUserName(string userName)
        {
            DAL_Account getAccount = new DAL_Account();
            return getAccount.getAccountByUserName(userName);
        }
        public int getType(string userName, string passWord)
        {
            DAL_Account getType = new DAL_Account();
            return getType.getType(userName, passWord);
        }
        public bool updateAccountProfile(BEL_Account acc, string newPassWord)
        {
            DAL_Account update = new DAL_Account();
            return update.updateAccountprofile(acc, newPassWord);
        }
        public bool addAccount(BEL_Account acc)
        {
            DAL_Account add = new DAL_Account();
            return add.addAccount(acc);
        }
        public bool updateAccount(string displayName, string userName,int type)
        {
            DAL_Account update = new DAL_Account();
            return update.updateAccount(displayName, userName, type);
        }
        public bool deleteAccount(string userName)
        {
            DAL_Account delete = new DAL_Account();
            return delete.deleteAccount(userName);
        }
        public bool resetPass(string username)
        {
            DAL_Account reset = new DAL_Account();
            return reset.resetPass(username);
        }
    }
}
