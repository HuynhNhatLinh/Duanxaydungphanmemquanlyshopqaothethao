using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.frm
{
    public partial class DoanhThuNgay : Form
    {
        public DoanhThuNgay()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Repost.DoanhThuBYDay nn=new Repost.DoanhThuBYDay();
            crystalReportViewer1.ReportSource = nn;
        }
    }
}
