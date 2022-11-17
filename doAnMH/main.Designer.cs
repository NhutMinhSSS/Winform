
namespace doAnMH
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.nmDiscoount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.cboSwicthTable = new System.Windows.Forms.ComboBox();
            this.btnSwithTable = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.cboFood = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscoount)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thongTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1007, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.adminToolStripMenuItem.Text = "Quản lý";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thongTinToolStripMenuItem
            // 
            this.thongTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thongTinToolStripMenuItem.Name = "thongTinToolStripMenuItem";
            this.thongTinToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thongTinToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinToolStripMenuItem.Click += new System.EventHandler(this.thôngTinToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem1_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flpTable.BackgroundImage")));
            this.flpTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpTable.Location = new System.Drawing.Point(12, 31);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(545, 476);
            this.flpTable.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsvBill);
            this.panel1.Location = new System.Drawing.Point(563, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 337);
            this.panel1.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(5, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(421, 331);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 138;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 77;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 75;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTotalPrice);
            this.panel2.Controls.Add(this.nmDiscoount);
            this.panel2.Controls.Add(this.btnDiscount);
            this.panel2.Controls.Add(this.cboSwicthTable);
            this.panel2.Controls.Add(this.btnSwithTable);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Location = new System.Drawing.Point(563, 441);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 66);
            this.panel2.TabIndex = 3;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtTotalPrice.Location = new System.Drawing.Point(135, 35);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(185, 27);
            this.txtTotalPrice.TabIndex = 5;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nmDiscoount
            // 
            this.nmDiscoount.Location = new System.Drawing.Point(253, 5);
            this.nmDiscoount.Name = "nmDiscoount";
            this.nmDiscoount.Size = new System.Drawing.Size(67, 22);
            this.nmDiscoount.TabIndex = 4;
            this.nmDiscoount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDiscount
            // 
            this.btnDiscount.Location = new System.Drawing.Point(135, 3);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(110, 27);
            this.btnDiscount.TabIndex = 3;
            this.btnDiscount.Text = "Giảm giá (%)";
            this.btnDiscount.UseVisualStyleBackColor = true;
            // 
            // cboSwicthTable
            // 
            this.cboSwicthTable.FormattingEnabled = true;
            this.cboSwicthTable.Location = new System.Drawing.Point(1, 37);
            this.cboSwicthTable.Name = "cboSwicthTable";
            this.cboSwicthTable.Size = new System.Drawing.Size(112, 24);
            this.cboSwicthTable.TabIndex = 2;
            // 
            // btnSwithTable
            // 
            this.btnSwithTable.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSwithTable.Location = new System.Drawing.Point(0, 0);
            this.btnSwithTable.Name = "btnSwithTable";
            this.btnSwithTable.Size = new System.Drawing.Size(113, 32);
            this.btnSwithTable.TabIndex = 1;
            this.btnSwithTable.Text = "Chuyển bàn";
            this.btnSwithTable.UseVisualStyleBackColor = false;
            this.btnSwithTable.Click += new System.EventHandler(this.btnSwithTable_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCheck.Location = new System.Drawing.Point(326, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(103, 59);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Thanh Toán";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.nmFoodCount);
            this.panel3.Controls.Add(this.btnAddFood);
            this.panel3.Controls.Add(this.cboFood);
            this.panel3.Controls.Add(this.cboCategory);
            this.panel3.Location = new System.Drawing.Point(566, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 64);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(237, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số lượng";
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(251, 33);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(53, 22);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddFood.Location = new System.Drawing.Point(323, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(100, 54);
            this.btnAddFood.TabIndex = 2;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // cboFood
            // 
            this.cboFood.FormattingEnabled = true;
            this.cboFood.Location = new System.Drawing.Point(3, 33);
            this.cboFood.Name = "cboFood";
            this.cboFood.Size = new System.Drawing.Size(228, 24);
            this.cboFood.TabIndex = 1;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(3, 3);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(228, 24);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1007, 519);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Phần mềm quản lý quán ăn";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscoount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thongTinToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.ComboBox cboFood;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.NumericUpDown nmDiscoount;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.ComboBox cboSwicthTable;
        private System.Windows.Forms.Button btnSwithTable;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}