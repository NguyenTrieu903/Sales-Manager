using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussniessLogic;
namespace Final_test_CodeFirst
{
    public partial class frmMain : Form
    {
        BussniessLogin BG = new BussniessLogin();
        Generally frm = new Generally();
        public frmMain()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void XemDanhMuc(int danhmuc)
        {
            Form frm = new Generally();
            frm.Text = danhmuc.ToString();
            OpenChildForm(frm);
            //frm.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.lblTenHienThi= BG.getTen()
        }
        private void btnNvNV_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }

        private void btnNvHH_Click(object sender, EventArgs e)
        {
            frmHangHoa f = new frmHangHoa();
            f.ShowDialog();
        }

        private void btnNvKH_Click(object sender, EventArgs e)
        {
            frmKH f = new frmKH();
            f.ShowDialog();
        }

        private void btnNvNCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap f = new frmNhaCungCap();
            f.ShowDialog();
        }

        private void btnNvHD_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.ShowDialog();
        }

        private void btnNvCTHD_Click(object sender, EventArgs e)
        {
            frmDoanhThu f = new frmDoanhThu();
            f.ShowDialog();
        }

        private void btnDmNV_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        private void btnDmKH_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        private void btnDmHH_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }
        private void btnDmNCC_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }
        private void btnDmHD_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }
        private void btnDmCTHD_Click(object sender, EventArgs e)
        {
            frmChitietHD f = new frmChitietHD();
            f.ShowDialog();
        }
        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTK f = new frmTaoTK();
            f.ShowDialog();
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK f = new frmDoiMK();
            f.ShowDialog();
        }

        private void doanhSốBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThu f = new frmDoanhThu();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
