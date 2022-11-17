using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doAnMH
{
    public partial class fReportView : Form
    {
        public fReportView()
        {
            InitializeComponent();
        }

        private void fReportView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet.USP_GETLISTBILLBYDATE' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet.USP_GETLISTBILLBYYEAR' table. You can move, or remove it, as needed.
            loadDateTimePicker();
        }
        private void loadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dpkCheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dpkCheckOut.Value = dpkCheckIn.Value.AddMonths(1).AddDays(-1);
        }
        private void btnTK_Click(object sender, EventArgs e)
        {
            DateTime checkin = dpkCheckIn.Value.Date;
            DateTime checkout = dpkCheckOut.Value.Date;
            this.USP_GETLISTBILLBYDATETableAdapter.Fill(this.QuanLyQuanCafeDataSet.USP_GETLISTBILLBYDATE,checkin,checkout);
            this.rpDoanhThu.RefreshReport();
        }

    }
}
