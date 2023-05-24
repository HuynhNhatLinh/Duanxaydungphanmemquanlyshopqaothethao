using QLBH.Repost;
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
    public partial class InPhieuNhap : Form
    {
        public InPhieuNhap()
        {
            InitializeComponent();
        }
        string phieunhap = uc.ucnhaphang.hoadon;
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rpPhieuNhap tt = new rpPhieuNhap();
            tt.Refresh();
            tt.SetParameterValue("@mapn", phieunhap);
            crystalReportViewer1.ReportSource = tt;
        }
    }
}
