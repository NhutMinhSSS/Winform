
namespace doAnMH
{
    partial class fReportView
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GETLISTBILLBYDATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyQuanCafeDataSet = new doAnMH.QuanLyQuanCafeDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dpkCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTK = new System.Windows.Forms.Button();
            this.dpkCheckIn = new System.Windows.Forms.DateTimePicker();
            this.rpDoanhThu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GETLISTBILLBYDATETableAdapter = new doAnMH.QuanLyQuanCafeDataSetTableAdapters.USP_GETLISTBILLBYDATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GETLISTBILLBYDATEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // USP_GETLISTBILLBYDATEBindingSource
            // 
            this.USP_GETLISTBILLBYDATEBindingSource.DataMember = "USP_GETLISTBILLBYDATE";
            this.USP_GETLISTBILLBYDATEBindingSource.DataSource = this.QuanLyQuanCafeDataSet;
            // 
            // QuanLyQuanCafeDataSet
            // 
            this.QuanLyQuanCafeDataSet.DataSetName = "QuanLyQuanCafeDataSet";
            this.QuanLyQuanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dpkCheckOut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTK);
            this.groupBox1.Controls.Add(this.dpkCheckIn);
            this.groupBox1.Location = new System.Drawing.Point(138, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 122);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đến ngày : ";
            // 
            // dpkCheckOut
            // 
            this.dpkCheckOut.Location = new System.Drawing.Point(463, 50);
            this.dpkCheckOut.Name = "dpkCheckOut";
            this.dpkCheckOut.Size = new System.Drawing.Size(251, 22);
            this.dpkCheckOut.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Từ ngày : ";
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(322, 83);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(81, 33);
            this.btnTK.TabIndex = 5;
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // dpkCheckIn
            // 
            this.dpkCheckIn.Location = new System.Drawing.Point(6, 50);
            this.dpkCheckIn.Name = "dpkCheckIn";
            this.dpkCheckIn.Size = new System.Drawing.Size(248, 22);
            this.dpkCheckIn.TabIndex = 3;
            // 
            // rpDoanhThu
            // 
            reportDataSource1.Name = "getBillByDate";
            reportDataSource1.Value = this.USP_GETLISTBILLBYDATEBindingSource;
            this.rpDoanhThu.LocalReport.DataSources.Add(reportDataSource1);
            this.rpDoanhThu.LocalReport.ReportEmbeddedResource = "doAnMH.Report1.rdlc";
            this.rpDoanhThu.Location = new System.Drawing.Point(12, 150);
            this.rpDoanhThu.Name = "rpDoanhThu";
            this.rpDoanhThu.ServerReport.BearerToken = null;
            this.rpDoanhThu.Size = new System.Drawing.Size(1024, 384);
            this.rpDoanhThu.TabIndex = 2;
            // 
            // USP_GETLISTBILLBYDATETableAdapter
            // 
            this.USP_GETLISTBILLBYDATETableAdapter.ClearBeforeFill = true;
            // 
            // fReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 546);
            this.Controls.Add(this.rpDoanhThu);
            this.Controls.Add(this.groupBox1);
            this.Name = "fReportView";
            this.Text = "In hóa đơn";
            this.Load += new System.EventHandler(this.fReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GETLISTBILLBYDATEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.DateTimePicker dpkCheckIn;
        private System.Windows.Forms.BindingSource USP_GETLISTBILLBYMONTHBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpkCheckOut;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rpDoanhThu;
        private System.Windows.Forms.BindingSource USP_GETLISTBILLBYDATEBindingSource;
        private QuanLyQuanCafeDataSet QuanLyQuanCafeDataSet;
        private QuanLyQuanCafeDataSetTableAdapters.USP_GETLISTBILLBYDATETableAdapter USP_GETLISTBILLBYDATETableAdapter;
    }
}