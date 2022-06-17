using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BussniessLogic;
namespace Final_test_CodeFirst
{
    public partial class frmHoaDon : Form
    {
        Context context = new Context();
        BussniessBill Lbn = new BussniessBill();
        BussniessInfoBill BB = new BussniessInfoBill();
        private bool Check = true;
        private bool ktra = true;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void init()
        {
            this.txtSoDTKH.ReadOnly = true;
            this.txtMaHD.ReadOnly = true;
            this.txtMaKH.ReadOnly = true;
            this.btnNew_KHTT.Enabled = false;
            this.btnNew.Enabled = true;
            this.btnXoa.Enabled = false;
            this.btnThem.Enabled = false;
            //this.btnLuu.Enabled = false;
            this.btnHuyHD.Enabled = false;
            this.gB1.Enabled = true;
            this.PnThongtin.Enabled = false;
            this.dgvChitietHD.Enabled = false;
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            init();
        }
        public void LoadData()
        {
            DataTable dt = Lbn.getMaNV();
            cboMaNV.DataSource = dt;
            cboMaNV.DisplayMember = "Id";
            cboMaNV.ValueMember = "Id";
            cboMathang.DataSource = BB.getSector();
            cboMathang.DisplayMember = "Sectorname";
            cboMathang.ValueMember = "IdSectors";
            this.cboTenhang.DataSource = BB.getGoodname(cboMathang.Text.ToString());
            this.cboTenhang.DisplayMember = "Goodsname";
            this.txtTenNV.Text = Lbn.getTenNV(cboMaNV.Text.ToString());
        }
        private void cboMathang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTenhang.DataSource = BB.getGoodname(cboMathang.Text.ToString());
            this.cboTenhang.DisplayMember = "Goodsname";
        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            float x = 0;
            if (string.IsNullOrEmpty(txtSoluong.Text.ToString()))
            {
                this.txtThanhtien.Text = "0";
            }
            else
            {
                x = float.Parse(txtSoluong.Text.ToString());
                this.txtThanhtien.Text = (x * float.Parse(txtDongia.Text.ToString())).ToString();
            }
        }
        private void cboGiamgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtThanhtien.Text = ((float.Parse(txtDongia.Text.ToString()) * float.Parse(txtSoluong.Text.ToString())) -
                (float.Parse(txtDongia.Text.ToString()) * float.Parse(txtSoluong.Text.ToString()) * int.Parse(cboGiamgia.Text.ToString()) / 100)).ToString();
        }
        private void cboTenhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtDongia.Text = BB.getPrice(this.cboTenhang.Text.ToString());
        }
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtTenNV.Text = Lbn.getTenNV(this.cboMaNV.Text.ToString());
        }
        public static float tongtien;
        private void btnNew_Click(object sender, EventArgs e)
        {
            string mak = random();
            string mah = random();
            DialogResult tl =
                MessageBox.Show("Bạn có muốn tạo hóa đơn với khách hàng thân thiết?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                this.txtSoDTKH.ReadOnly = false;
                MessageBox.Show("Vui lòng điền vào ô số điện thoại của khách hàng rồi sau đó nhấn vào ô Tạo mới hóa đơn với khách hàng thân thiết",
                                   "Thông báo",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                this.btnNew_KHTT.Enabled = true;
                this.gB1.Enabled = true;
            }
            else
            {
                this.txtSoDTKH.ReadOnly = true;
                if (Check)
                {
                    Lbn.AddKH(mak, " ");
                    Lbn.AddBill(mah, mak, cboMaNV.Text.ToString(), dtp1.Value, tongtien);
                    this.gB1.Enabled = true;
                    this.PnThongtin.Enabled = true;
                    this.dgvChitietHD.Enabled = true;
                    this.txtMaHD.Text = mah;
                    this.txtMaKH.Text = mak;
                }
                else
                {
                    Lbn.AddKH(mak, " ");
                    Lbn.AddBill(mah, mak, cboMaNV.Text.ToString(), dtp1.Value, tongtien);
                    this.gB1.Enabled = true;
                    this.PnThongtin.Enabled = true;
                    this.dgvChitietHD.Enabled = true;
                    this.txtMaHD.Text = mah;
                    this.txtMaKH.Text = mak;
                }
                this.gB1.Enabled = false;
            }
            //this.btnLuu.Enabled = true;
            this.btnHuyHD.Enabled = true;
            this.btnThem.Enabled = true;
            this.btnNew.Enabled = false;
            this.btnXoa.Enabled = false;
            this.PnThongtin.Enabled = true;
            this.dgvChitietHD.Enabled = true;
        }
        public static float tong = 0;
        public static int demSua=0;
        public static int soluong2 = 0;
        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            this.btnNew.Enabled = true;
            Lbn.DeleteBill(txtMaHD.Text.ToString());
            Check = false;
            this.cboGiamgia.ResetText();
            this.txtDongia.ResetText();
            this.txtSoluong.ResetText();
            this.txtThanhtien.ResetText();
            this.txtMaHD.ResetText();
            this.txtTongTien.ResetText();
            this.txtSoDTKH.ResetText();
            dgvChitietHD.DataSource = null;
            this.txtMaKH.ResetText();
            this.gB1.Enabled = true;
        }
        public static string random()
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random rng = new Random();

            string randomString = RandomString(4, chars, rng);
            return randomString;
        }
        public static string RandomString(int n, char[] chars, Random rng)
        {
            Shuffle(chars, rng);
            return new string(chars, 0, n);
        }

        public static void Shuffle(char[] array, Random rng)
        {
            for (int n = array.Length; n > 1;)
            {
                int k = rng.Next(n);
                --n;
                char temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtSoDT_Validiting(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoDTKH.Text))
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void btnNew_KHTT_Click(object sender, EventArgs e)
        {
            this.gB1.Enabled = false;
            this.btnNew_KHTT.Enabled = false;
            this.txtSoDTKH.Focus();
            string mak = random();
            string mah = random();
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Lbn.AddKH(mak, txtSoDTKH.Text.ToString());
                Lbn.AddBill(mah, mak, cboMaNV.Text.ToString(), dtp1.Value, tongtien);
                this.txtMaHD.Text = mah;
                this.txtMaKH.Text = mak;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboGiamgia.Text.ToString()))
            {
                BB.AddBillInfo(txtMaHD.Text.ToString(), cboTenhang.Text.ToString(), float.Parse(txtDongia.Text.ToString()),
                    float.Parse(txtSoluong.Text.ToString()), 0);
            }
            else
            {
                BB.AddBillInfo(txtMaHD.Text.ToString(), cboTenhang.Text.ToString(), float.Parse(txtDongia.Text.ToString()),
                    float.Parse(txtSoluong.Text.ToString()), int.Parse(cboGiamgia.Text.ToString()));
            }
            dgvChitietHD.DataSource = BB.getInfoBill(txtMaHD.Text.ToString());
            txtTongTien.Text = BB.getTotalMoney(txtMaHD.Text.ToString()).ToString();
            Lbn.updateBill(txtMaHD.Text.ToString(), float.Parse(txtTongTien.Text));
            Lbn.updateSL(cboTenhang.Text.ToString(), Lbn.getSL(cboTenhang.Text.ToString()), int.Parse(txtSoluong.Text.ToString()));
            this.btnThem.Enabled = true;
            this.btnXoa.Enabled = true;
            this.cboMathang.ResetText();
            this.cboTenhang.ResetText();
            this.txtDongia.ResetText();
            this.txtSoluong.ResetText();
            this.cboGiamgia.ResetText();
            this.txtThanhtien.ResetText();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dgvChitietHD.CurrentCell.RowIndex;
            string Ma = dgvChitietHD.Rows[r].Cells[1].Value.ToString();
            string tenhng = dgvChitietHD.Rows[r].Cells[1].Value.ToString();
            int soluong = int.Parse(dgvChitietHD.Rows[r].Cells[2].Value.ToString());
            string MaHH = BB.getMaHH(Ma);
            DialogResult tl =
                MessageBox.Show("Bạn chắc xóa không",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                BB.updateSL_2(tenhng, Lbn.getSL(tenhng), soluong);
                BB.DeleteBillInfo(MaHH, txtMaHD.Text.ToString());
                MessageBox.Show("Xóa thành công",
                                   "Thành Công",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                dgvChitietHD.DataSource = BB.getInfoBill(txtMaHD.Text.ToString());
                this.txtTongTien.Text = (BB.getTotalMoney(txtMaHD.Text.ToString())).ToString();
                Lbn.updateBill(txtMaHD.Text.ToString(), float.Parse(txtTongTien.Text));
            }
        }
    }
}
