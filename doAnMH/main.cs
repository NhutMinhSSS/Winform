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
    public partial class fMain : Form
    {
        private BEL_Account loginAccount = null;
       
        public fMain(BEL_Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        public BEL_Account LoginAccount
        {
            get { return this.loginAccount; }
            set { this.loginAccount = value; changAccount(loginAccount.Type,loginAccount.DisPlayName); }
        }
        public void changAccount(int type,string name)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thongTinToolStripMenuItem.Text += " : " + name;
        }
        private void fMain_Load(object sender, EventArgs e)
        {
            showTable();
            loadCategory(cboCategory);
            loadTransTable(cboSwicthTable);
        }
        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            fAccountProfile fAC = new fAccountProfile(loginAccount);
            fAC.ShowDialog();
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginACC = loginAccount;
            f.ShowDialog();
            showTable();
            loadCategory(cboCategory);
            loadTransTable(cboSwicthTable);
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFood(cboCategory.Text);
        }
        private void showTable()
        {
            flpTable.Controls.Clear();
            DataTable dt = new DataTable();
            BAL_Table processTable = new BAL_Table();
            BAL_Bill processBill = new BAL_Bill();
            dt = processTable.showTable();
            foreach(DataRow drow in dt.Rows)
            {
                Button btn = new Button() {Width = BEL_Table.TableWidth, Height = BEL_Table.TableHeight};
                btn.Text = drow["TABLENAME"] + Environment.NewLine + drow["TABLESTATUS"];
                btn.Click += btn_click;
                btn.Tag = drow["ID"]; 
                switch (drow["TABLESTATUS"])
                {
                    case "Trống" : btn.BackColor = Color.Aqua;
                        break;
                    default: btn.BackColor = Color.LightPink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
            
        }
        private void loadTransTable(ComboBox cbo)
        {
            BAL_Table showTable = new BAL_Table();
            DataTable dt = new DataTable();
            dt = showTable.showTable();
            cbo.Items.Clear();
            string nameT = null;
            foreach(DataRow dr in dt.Rows)
            {
                nameT = dr["TABLENAME"].ToString();
                cbo.Items.Add(nameT);
            }
            cbo.SelectedIndex = 0;
        }
        private void showBill(int id)
        {
            DataTable dt = new DataTable();
            BAL_Table showFoodTable = new BAL_Table();
            dt = showFoodTable.showFoodTable(id);
            lsvBill.Items.Clear();
            float totalPrice = 0;
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lsvItem = new ListViewItem(dr["FNAME"].ToString());
                lsvItem.SubItems.Add(dr["COUNTBILL"].ToString());
                lsvItem.SubItems.Add(dr["PRICE"].ToString());
                lsvItem.SubItems.Add(dr[3].ToString());
                totalPrice += float.Parse(dr[3].ToString());
                lsvBill.Items.Add(lsvItem);
            }
            txtTotalPrice.Text = totalPrice.ToString();
        }
        private void btn_click(object sender,EventArgs e)
        {
            int idTable = int.Parse((sender as Button).Tag.ToString());
            lsvBill.Tag = (sender as Button).Tag;
            showBill(idTable);
        }
        private void loadCategory(ComboBox cbo)
        {
            DataTable dt = new DataTable();
            BAL_FoodCategory loadCategory = new BAL_FoodCategory();
            dt = loadCategory.loadCategory();
            cbo.Items.Clear();
            string nameCategory = null;
            foreach(DataRow dr in dt.Rows)
            {
                nameCategory = dr["FCNAME"].ToString();
                cbo.Items.Add(nameCategory);
            }
            cbo.SelectedIndex = 0;
        }
        private int getIDFC(string Name)
        {
            BAL_FoodCategory getID = new BAL_FoodCategory();
            int result = getID.getIDCategory(Name);
            return result;
        }
        private void loadFood(string name)
        {
            DataTable dt = new DataTable();
            BAL_Food loadFood = new BAL_Food();
            int id = getIDFC(name);
            dt = loadFood.loadFood(id);
            string nameFood = null;
            cboFood.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                nameFood = dr["FNAME"].ToString();
                cboFood.Items.Add(nameFood);
            }
            if (cboFood.Items.Count > 0)
                cboFood.SelectedIndex = 0;
            else cboFood.Text = "";
        }
        private void addBill()
        {
            try
            {
                int billTable = int.Parse(lsvBill.Tag.ToString());
                DateTime checkIn = System.DateTime.Now;
                DateTime? checkOut = null;
                int billStatus = 0;
                int discount = 0;
                BEL_Bill bill = new BEL_Bill(checkIn, checkOut, billTable, billStatus,discount);
                BAL_Bill addBill = new BAL_Bill();
                bool result = addBill.addBill(bill);
                //if (result == true)
                //    MessageBox.Show("Đặt bàn thành công");
                //else MessageBox.Show("không thành công");

            }
            catch(Exception err)
            {
                throw;
            }
        }
        private bool addBillInfo(BEL_billInfo billInfo)
        {
            BEL_billInfo bInfor = new BEL_billInfo(billInfo.IDBill, billInfo.IDFood, billInfo.CountBill,billInfo.Status);
            BAL_BillInfo addBillInfo = new BAL_BillInfo();
            BAL_Table processTable = new BAL_Table();
            BAL_Bill checkBill = new BAL_Bill();
            int idTable = int.Parse(lsvBill.Tag.ToString());
            int idBill = checkBill.getUnCheckBByTable(idTable);
            try
            {
                bool result = addBillInfo.addBillInfo(billInfo);
                if (!result)
                {//MessageBox.Show("Thêm thành công món " + cboFood.Text);
                    MessageBox.Show("không thành công");
                }
                else
                {
                    if (processTable.checkBillInfo(idBill, idTable))
                        showTable();
                }
                return result;
            }
            catch(Exception err)
            {
                throw;
            }
        }
        private bool addBillInfoExits(BEL_billInfo billInfo,int count)
        {
            BEL_billInfo bInfor = new BEL_billInfo(billInfo.IDBill, billInfo.IDFood, billInfo.CountBill, billInfo.Status);
            BAL_BillInfo addBExits = new BAL_BillInfo();
            bool result =addBExits.addBillInfoExits(billInfo, count);
            return result;
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int idTable = int.Parse(lsvBill.Tag.ToString());
            BAL_Bill checkBill = new BAL_Bill();
            BAL_Food getid = new BAL_Food();
            BAL_Table processTable = new BAL_Table();
            int idBill = checkBill.getUnCheckBByTable(idTable);
            int idFood = getid.getID(cboFood.Text);
            int countBill = int.Parse(nmFoodCount.Value.ToString());
            if (idFood != -1)
            {
                if (idBill == -1)
                {
                    addBill();
                    idBill = checkBill.getUnCheckBByTable(idTable);
                    BEL_billInfo bInfo = new BEL_billInfo(idBill, idFood, countBill, "True");
                    if (addBillInfo(bInfo))
                        processTable.checkBillInfo(idBill, idTable);
                }
                else
                {
                    BEL_billInfo bInfo = new BEL_billInfo(idBill, idFood, countBill, "True");
                    if (addBillInfoExits(bInfo, countBill))
                    {
                        processTable.checkBillInfo(idBill, idTable);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng không hợp lệ, không thể thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else MessageBox.Show("Thêm món không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            showBill(idTable);
            showTable();

            //checkInTable();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            BAL_Bill processBill = new BAL_Bill();
            BAL_Table processTable = new BAL_Table();
            int idTable = int.Parse(lsvBill.Tag.ToString());
            int idBill = processBill.getUnCheckBByTable(idTable);
            int discount = (int)nmDiscoount.Value;
            float totalPrice = float.Parse(txtTotalPrice.Text);
            float finalPrice =totalPrice - (totalPrice / 100 * discount);
            if(idBill !=-1)
            {
                string nameTable = processTable.getNameTable(idTable);
                DialogResult result = MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn cho {0}\n Bạn được giảm {1}% cho hóa đơn\nTổng tiền là : {2} \nTổng tiền sau giảm giá là : {3}", nameTable,discount,totalPrice,finalPrice), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    processBill.checkOut(idBill,discount,finalPrice);
                    showBill(idTable);
                    if (processTable.checkBill(idTable))
                           showTable();
                    //checkOutTable();
                }
            }
            else
            {
                MessageBox.Show("Bàn trống không thể thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSwithTable_Click(object sender, EventArgs e)
        {
            BAL_Bill processBill = new BAL_Bill();
            BAL_Table processTable = new BAL_Table();
            DialogResult result = MessageBox.Show("Bạn có muốn chuyển bàn ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                if (lsvBill.Tag==null)
                    MessageBox.Show("Bạn chưa chọn bàn cần chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    int idTable = int.Parse(lsvBill.Tag.ToString());
                    int idBill = processBill.getUnCheckBByTable(idTable);
                    int idtransTable = int.Parse(processTable.getIDTable(cboSwicthTable.Text).ToString());
                    if (idTable != idtransTable)
                    {

                        if (processBill.transTable(idTable, idtransTable))
                        {
                            processTable.checkBill(idTable);
                            showBill(idtransTable);

                            processTable.checkBill(idtransTable);
                            processTable.checkBillInfo(idBill, idtransTable);
                        }
                        else
                        {
                            MessageBox.Show("Không thể chuyển qua bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể chuyển cùng bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

            showTable();
        }
       
    }
}
