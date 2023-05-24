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
    public partial class DoanhThuThang : Form
    {
        public DoanhThuThang()
        {
            InitializeComponent();
        }

        private void DoanhThuThang_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Repost.DoanhThuBYThang cc=new Repost.DoanhThuBYThang();
            crystalReportViewer1.ReportSource = cc;
        }
    }
}
