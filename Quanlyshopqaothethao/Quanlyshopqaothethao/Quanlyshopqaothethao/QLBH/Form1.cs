using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucSanPham());
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucloaisanpham());
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.uckhachhang());
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucdoimk());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cc = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Thông Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (cc == DialogResult.Yes)
                this.Close();
            else if (cc == DialogResult.No)
                MessageBox.Show("Mời bạn tiếp tục sử dụng phần mềm",
                    "Thông Báo");
            
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucnhacungcap());
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucnhanvien());
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.banhang());
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucnhaphang());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm.frmrpsanpham frm = new frm.frmrpsanpham();
            frm.ShowDialog();
        }

        private void sảnPhẩmBYIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.SanPhambyLSP frm = new frm.SanPhambyLSP();
            frm.ShowDialog();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmPhieuNhap frm = new frm.frmPhieuNhap();
            frm.ShowDialog();
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmHoadon frm = new frm.frmHoadon();
            frm.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucTraCuuHoaDon());
        }

        private void phiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kn.ThemUserControl(pnMain, new uc.ucTraCuuphieunhap());
        }

        private void hóaĐơnTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmXemHoaDonTheoNgay frm = new frm.frmXemHoaDonTheoNgay();
            frm.ShowDialog();
        }

        private void phiếuNhậpTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmPhieuNhapByDay aa=new frm.frmPhieuNhapByDay();
            aa.ShowDialog();
        }

        private void hàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmHangTon aa = new frm.frmHangTon();
            aa.ShowDialog();
        }

        private void hóaĐơnTheoNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmhoadonbynhanvien aa=new frm.frmhoadonbynhanvien();
            aa.ShowDialog();
        }

        private void phiếuNhậpTheoNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.frmPhieuNhapByNV aa = new frm.frmPhieuNhapByNV();
            aa.ShowDialog();
        }

        private void traCứuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void theoThángToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm.DoanhThuBYThang aa = new frm.DoanhThuBYThang();
            aa.ShowDialog();
        }

        private void theoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.DoanhThuByDay aa=new frm.DoanhThuByDay();
            aa.ShowDialog();
        }

        private void theoNgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm.frmdoanhthutheongay aa = new frm.frmdoanhthutheongay();
            aa.ShowDialog();
        }
    }
}
