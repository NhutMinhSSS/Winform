using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using BAL;
using BEL;

namespace doAnMH
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
        private void cebPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            if (cebPass.Checked==true)
            {
                txtPass.UseSystemPasswordChar = false;
            }
        }
        private bool Login(string userName, string passWord)
        {
            BAL_Account Login = new BAL_Account();
            return Login.login(userName, passWord);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            BAL_Encryption encry = new BAL_Encryption();
            string encryPass = encry.encryption(txtPass.Text);
            if (Login(txtUser.Text, encryPass))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transForm();
               
            }
            else
            {
                BAL_Account validate = new BAL_Account();
                bool resultUser = validate.validateUser(txtUser.Text);
                bool resultPass = validate.validatePass(encryPass);
                if (!resultUser && !resultPass)
                    MessageBox.Show("UserName hoặc PassWord không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!resultUser)
                    MessageBox.Show("UserName không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("PassWord không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketQua = MessageBox.Show("Bạn có Chắc muốn Thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == ketQua)
            {
                e.Cancel = true;
            }
        }
        private void transForm()
        {
            BEL_Account loginAccount = new BEL_Account();
            BAL_Account getAccount = new BAL_Account();
            loginAccount = getAccount.getAccountByUserName(txtUser.Text);
            fMain m = new fMain(loginAccount);
            //fAccountProfile fapf = new fAccountProfile(loginAccount);
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

      
    }
}
