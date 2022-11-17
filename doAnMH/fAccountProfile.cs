using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace doAnMH
{
    public partial class fAccountProfile : Form
    {
        private BEL_Account acc;
        public BEL_Account Acc
        {
            get { return this.acc; }
            set { this.acc = value; }
        }
        public fAccountProfile(BEL_Account account)
        {
            InitializeComponent();
            this.Acc = account;
        }
        
        private void showAccountProFile()
        {
            BAL_Account processA = new BAL_Account();
            DataTable dt = new DataTable();
            dt = processA.showAccountProFile(acc.UserName, acc.PassWord);
            txtDisplayName.Text = dt.Rows[0]["DISPLAYNAME"].ToString();
            txtUser.Text = dt.Rows[0]["USERNAME"].ToString();
        }
        private void updateAccount()
        {
            BAL_Encryption encry = new BAL_Encryption();
            string disPlayName = txtDisplayName.Text;
            string userName = txtUser.Text;
            string oldPass = encry.encryption(txtOldPass.Text);
            string newPass = encry.encryption(txtNewPass.Text);
            string rePass = encry.encryption(txtRePass.Text);
            BAL_Account processA = new BAL_Account();
            int type = processA.getType(userName, oldPass);
            if (oldPass == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (newPass == "") MessageBox.Show("Vui lòng nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (type != -1)
                {
                    if (!newPass.Equals(rePass))
                        MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else if (userName == "admin")
                    {
                        MessageBox.Show("Đây là tài khoản mặc định không thể thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {
                        BEL_Account acc = new BEL_Account(disPlayName, userName, oldPass, type);
                        bool result = processA.updateAccountProfile(acc, newPass);

                        if (result)
                        {
                            MessageBox.Show("Cập nhật thành công, vui lòng đăng xuất để cập nhật lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Vui lòng nhập đúng mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            showAccountProFile();
        }
    }
}
