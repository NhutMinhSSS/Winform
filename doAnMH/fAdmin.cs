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
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }
        private string IDFoodSelected = null;
        private string IDCategorySelected = null;
        private string IDTableSelected = null;
        private string IDUserSelected = null;
        public BEL_Account loginACC;
        private void fAdmin_Load(object sender, EventArgs e)
        {
            showAccount(dgvAccount);
            showFood(dgvFood);
            showCategory(dgvCategory);
            showTable(dgvTable);
            loadDateTimePicker();
            statisticsBill(dgviewBill, dpkF.Value, dpkT.Value);
            showBill(dgviewBill);
            showCategory(cboSearchFoodCategory);
            showAccountType(cboAccountType);
        }
        private void showAccount(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            BAL_Account showAccount = new BAL_Account();
            dt = showAccount.ShowAccount();
            dgv.DataSource = dt;
        }
        private void showFood(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            BAL_Food showFood = new BAL_Food();
            dt = showFood.showFood();
            dgv.DataSource = dt;
        }
        private void showCategory(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            BAL_FoodCategory showCategory = new BAL_FoodCategory();
            dt = showCategory.loadCategory();
            dgv.DataSource = dt;
        }
        private void showTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            BAL_Table loadTable = new BAL_Table();
            dt = loadTable.showTable();
            dgv.DataSource = dt;
        }
        private void showBill(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            BAL_Bill show = new BAL_Bill();
            dt = show.showBill();
            dgv.DataSource = dt;
        }
        private void statisticsBill(DataGridView dgv, DateTime checkIn, DateTime checkOut)
        {
            DataTable dt = new DataTable();
            BAL_Bill check = new BAL_Bill();
            dt = check.statisticsBill(checkIn, checkOut);
            dgv.DataSource = dt;
        }
        private void loadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dpkF.Value = new DateTime(today.Year, today.Month, 1);
            dpkT.Value = dpkF.Value.AddMonths(1).AddDays(-1);
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDFoodSelected = dgvFood.CurrentRow.Cells[0].Value.ToString().Trim();
            txtSearchFoodID.Text = dgvFood.CurrentRow.Cells["ID"].Value.ToString();
            txtSearchFoodName.Text = dgvFood.CurrentRow.Cells["FNAME"].Value.ToString();
            cboSearchFoodCategory.Text = dgvFood.CurrentRow.Cells["FCNAME"].Value.ToString();
            nmSearchFoodPrice.Value = decimal.Parse(dgvFood.CurrentRow.Cells["PRICE"].Value.ToString());

        }
        private void cleartxtFood()
        {
            txtSearchFoodID.Text = "";
            txtSearchFoodName.Text = "";
            cboSearchFoodCategory.Text = "";
            nmSearchFoodPrice.Value = 0;
        }
        private void btnViewFood_Click(object sender, EventArgs e)
        {
            showFood(dgvFood);
            cleartxtFood();
        }
        private void showCategory(ComboBox cbo)
        {
            BAL_FoodCategory load = new BAL_FoodCategory();
            DataTable dt = new DataTable();
            dt = load.loadCategory();
            string name = null;
            foreach (DataRow dr in dt.Rows)
            {
                name = dr["FCNAME"].ToString();
                cbo.Items.Add(name);
            }
            cbo.SelectedIndex = 0;
        }
        private void showAccountType(ComboBox cbo)
        {
            cbo.Items.Add("admin");
            cbo.Items.Add("staff");
            cbo.SelectedIndex = 0;
        }
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDCategorySelected = dgvCategory.CurrentRow.Cells[0].Value.ToString().Trim();
            txtCategoryID.Text = dgvCategory.CurrentRow.Cells["ID"].Value.ToString();
            txtCategoryName.Text = dgvCategory.CurrentRow.Cells["FCNAME"].Value.ToString();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDTableSelected = dgvTable.CurrentRow.Cells[0].Value.ToString().Trim();
            txtTableID.Text = dgvTable.CurrentRow.Cells["ID"].Value.ToString();
            txtTableName.Text = dgvTable.CurrentRow.Cells["TABLENAME"].Value.ToString();
            cboTableStatus.Text = dgvTable.CurrentRow.Cells["TABLESTATUS"].Value.ToString();
        }
        private string userNameSelected = null;
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDUserSelected = dgvAccount.CurrentRow.Cells[0].Value.ToString().Trim();
            txtAccountName.Text = dgvAccount.CurrentRow.Cells["DISPLAYNAME"].Value.ToString();
            txtAccountUser.Text = dgvAccount.CurrentRow.Cells["USERNAME"].Value.ToString();
            int type = (int)dgvAccount.CurrentRow.Cells["TYPE"].Value;
            cboAccountType.Text = showType(type);
            userNameSelected = txtAccountUser.Text;
        }
        private string showType(int type)
        {
            string status = null;
            if (type == 1)
                status = "admin";
            else status = "staff";
            return status;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            BAL_Food addFood = new BAL_Food();
            BAL_FoodCategory getID = new BAL_FoodCategory();
            string Fname = txtSearchFoodName.Text;
            int IDCategory = getID.getIDCategory(cboSearchFoodCategory.Text);
            float price = (float)nmSearchFoodPrice.Value;

            if (Fname == "")
            {
                MessageBox.Show("Bạn chưa nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thêm món không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    BEL_Food food = new BEL_Food(Fname, IDCategory, price, "True");
                    if (addFood.addFood(food))
                    {
                        MessageBox.Show("Thêm thành công món " + Fname + " vào danh sách thức ăn");
                        showFood(dgvFood);
                    }
                    else MessageBox.Show("Tên món bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            BAL_Food updateFood = new BAL_Food();
            BAL_FoodCategory getid = new BAL_FoodCategory();

            if (txtSearchFoodID.Text != "")
            {
                int idFood = int.Parse(txtSearchFoodID.Text);
                string Fname = txtSearchFoodName.Text;
                int idCategory = getid.getIDCategory(cboSearchFoodCategory.Text);
                float price = (float)nmSearchFoodPrice.Value;
                if (txtSearchFoodName.Text == "")
                    MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa món không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        BEL_Food food = new BEL_Food(Fname, idCategory, price, "True");
                        if (updateFood.updateFood(food, idFood))
                        {
                            MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showFood(dgvFood);
                        }
                        else MessageBox.Show("Không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else MessageBox.Show("Bạn chưa chọn món cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            BAL_Food deleteFood = new BAL_Food();
            if (txtSearchFoodID.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    int idFood = int.Parse(txtSearchFoodID.Text);
                    if (deleteFood.deleteFood(idFood))
                    {
                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showFood(dgvFood);
                    }
                    else MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn món cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            BAL_FoodCategory addC = new BAL_FoodCategory();
            string FCname = txtCategoryName.Text;

            if (FCname != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    BEL_FoodCategory category = new BEL_FoodCategory(FCname, "True");
                    if (addC.addCategory(category))
                    {
                        MessageBox.Show("Bạn đã thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showCategory(dgvCategory);
                    }
                    else MessageBox.Show("Tên bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Bạn chưa nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateCategorry_Click(object sender, EventArgs e)
        {
            BAL_FoodCategory updateC = new BAL_FoodCategory();
            string FCName = txtCategoryName.Text;

            if (txtCategoryID.Text == "")
                MessageBox.Show("Bạn chưa chọn danh mục cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn chỉnh sửa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    int id = int.Parse(txtCategoryID.Text);
                    if (FCName == "")
                        MessageBox.Show("Vui lòng nhập tên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        BEL_FoodCategory category = new BEL_FoodCategory(FCName, "True");
                        if (updateC.updateCategory(category, id))
                        {
                            MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showCategory(dgvCategory);
                        }
                        else MessageBox.Show("Không sửa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            BAL_FoodCategory deleteC = new BAL_FoodCategory();
            if (txtCategoryID.Text == "")
                MessageBox.Show("Bạn chưa chọn danh mục cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    int id = int.Parse(txtCategoryID.Text);
                    if (deleteC.deleteCategory(id))
                    {
                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showCategory(dgvCategory);
                    }
                    else MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            showCategory(dgvCategory);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            BAL_Table addTable = new BAL_Table();
            string tableName = txtTableName.Text;
            if (tableName == "")
                MessageBox.Show("Bạn chưa nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    BEL_Table table = new BEL_Table(tableName, "Trống", "True");
                    if (addTable.addTable(table))
                    {
                        MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable(dgvTable);
                    }
                    else MessageBox.Show("Tên bàn bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            BAL_Table updateTable = new BAL_Table();
            string tableName = txtTableName.Text;
            string tableStaus = cboTableStatus.Text;
            if (txtTableID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn cần chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (tableName == "")
                    MessageBox.Show("Bạn chưa nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    int idTable = int.Parse(txtTableID.Text);
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn sừa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {
                        if (tableStaus == "Có người")
                            MessageBox.Show("Bàn đang có người không thể chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            BEL_Table table = new BEL_Table(tableName, "Trống", "True");
                            if (updateTable.updateTable(table, idTable))
                            {
                                MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                showTable(dgvTable);
                            }
                            else MessageBox.Show("Không sửa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            BAL_Table deleteTable = new BAL_Table();
            if (txtTableID.Text == "")
                MessageBox.Show("Bạn chưa chọn bàn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    int id = int.Parse(txtTableID.Text);
                    string tableStatus = cboTableStatus.Text;
                    if(tableStatus=="Có người")
                    {
                        MessageBox.Show("Bàn đang có người không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (deleteTable.deleteTable(id))
                    {
                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showTable(dgvTable);
                    }
                    else MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            txtTableID.Text = "";
            txtTableName.Text = "";
            showTable(dgvTable);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            BAL_Account add = new BAL_Account();
            string userName = txtAccountUser.Text;
            string displayName = txtAccountName.Text;
            int type;
            if (cboAccountType.Text == "admin")
                type = 1;
            else type = 0;
            if (userName == "")
                MessageBox.Show("Bạn chưa chọn tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {

                    BEL_Account acc = new BEL_Account(displayName, userName, "0", type);
                    if (add.addAccount(acc))
                    {
                        MessageBox.Show("Bạn đã thêm thành công\n Mật khẩu mặt định là 0, vui lòng đăng nhặp và đổi lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showAccount(dgvAccount);
                    }
                    else MessageBox.Show("Tên tài khoản bị trùng, vui lòng đổi tên tài khoản khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            BAL_Account delete = new BAL_Account();
            string userName = txtAccountUser.Text;
            if (userName == "")
                MessageBox.Show("Bạn chưa Chọn tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (userName == "admin")
            {
                MessageBox.Show("Đây là tài khoản mặt định không thể thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (loginACC.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    if (delete.deleteAccount(userName))
                    {
                        MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showAccount(dgvAccount);
                    }
                    else MessageBox.Show("không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            BAL_Account update = new BAL_Account();
            string userName = txtAccountUser.Text;
            string displayName = txtAccountName.Text;
            int type;
            if (cboAccountType.Text == "admin")
                type = 1;
            else type = 0;
            if (userName == "")
                MessageBox.Show("Bạn chưa Chọn tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (userName == "admin")
            {
                MessageBox.Show("Đây là tài khoản mặt định không thể thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn chỉnh sửa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    if (!userNameSelected.Equals(userName))
                    {
                        MessageBox.Show("Bạn không thể đổi tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (update.updateAccount(displayName, userName, type))
                        {
                            MessageBox.Show("Bạn đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showAccount(dgvAccount);
                        }
                        else MessageBox.Show("Chỉnh sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = "";
            txtAccountUser.Text = "";
            showAccount(dgvAccount);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            BAL_Account reset = new BAL_Account();
            string userName = txtAccountUser.Text;
            if (userName == "")
                MessageBox.Show("Bạn chưa Chọn tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (userName == "admin")
            {
                MessageBox.Show("Đây là tài khoản mặt định không thể thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    if (reset.resetPass(userName))
                    {
                        MessageBox.Show("Bạn đã đặt mật khẩu là 0 cho tài khoản " + userName,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void searchFood(DataGridView dgv)
        {
            string FoodName = txtSearchFood.Text;
            BAL_Food search = new BAL_Food();
            DataTable dt = new DataTable();
            dt = search.searchFood(FoodName);
            dgv.DataSource = dt;
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            searchFood(dgvFood);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            fReportView fp = new fReportView();
            this.Hide();
            fp.ShowDialog();
            this.Show();
        }

        private void btnVBill_Click(object sender, EventArgs e)
        {
            statisticsBill(dgviewBill, dpkF.Value, dpkT.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fReportView fr = new fReportView();
            this.Hide();
            fr.ShowDialog();
            this.Show();

        }
    }
}
