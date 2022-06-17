using BussniessLogic;
using System;
using System.Data;
using System.Windows.Forms;
namespace Final_test_CodeFirst
{
    public partial class frmHangHoa : Form
    {
        private bool Sua = false;
        private DataTable dtC = new DataTable();
        BussniessGoods BG = new BussniessGoods();
        BussniessInfoBill BF = new BussniessInfoBill();
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnReload.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTrove.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadGoodsData();
            this.groupBox1.Enabled = false;
        }
        private void LoadGoodsData()
        {
            dtC = BG.getHangHoa();
            dvgGood.DataSource = dtC;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Sua)
            {
                DialogResult tl =
                MessageBox.Show("Bạn có muốn lưu những thay đổi này không?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    BG.UpdateGoods(txtIdHH.Text, txtNameGood.Text, cboMathang.Text, txtUnit.Text, txtPrice.Text, dtp1.Value, dtp2.Value,int.Parse(txtSoLuong.Text));
                    MessageBox.Show("Chỉnh sửa thành công!",
                        "Thành công!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadGoodsData();
                }

            }else
            {
                DialogResult tl =
                MessageBox.Show("Bạn có muốn thêm mặt hàng này không?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    BG.AddGoods(txtIdHH.Text, txtNameGood.Text, cboMathang.Text, txtUnit.Text, txtPrice.Text, dtp1.Value, dtp2.Value, int.Parse(txtSoLuong.Text));
                    MessageBox.Show("Thêm thành công!",
                        "Thành công!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadGoodsData();
                }
            }
            // Xoa du lieu trong textbox
            txtIdHH.ResetText();
            txtNameGood.ResetText();
            cboMathang.ResetText();
            txtUnit.ResetText();
            txtPrice.ResetText();
            dtp1.Value = DateTime.Today;
            dtp2.Value = DateTime.Today;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.txtIdHH.ReadOnly = true;
            this.cboMathang.DataSource = BF.getSector();
            this.cboMathang.DisplayMember = "Sectorname";
            this.cboMathang.ValueMember = "IdSectors";
            Sua = true;
            this.groupBox1.Enabled = true;
            int r = dvgGood.CurrentCell.RowIndex;
            this.txtIdHH.Text = dvgGood.Rows[r].Cells[0].Value.ToString();
            this.txtNameGood.Text = dvgGood.Rows[r].Cells[1].Value.ToString();
            //this.cboMathang.Text = dvgGood.Rows[r].Cells[2].Value.ToString();
            this.txtUnit.Text = dvgGood.Rows[r].Cells[3].Value.ToString();
            this.txtPrice.Text = dvgGood.Rows[r].Cells[4].Value.ToString();
            this.dtp1.Value = Convert.ToDateTime(dvgGood.Rows[r].Cells[5].Value);
            this.dtp2.Value = Convert.ToDateTime(dvgGood.Rows[r].Cells[6].Value);
            this.txtSoLuong.Text = dvgGood.Rows[r].Cells[7].Value.ToString();
            this.btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaNCC
            this.txtIdHH.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtIdHH.ReadOnly = false;
            Sua = false;
            this.groupBox1.Enabled = true;
            this.cboMathang.DataSource = BF.getSector();
            this.cboMathang.DisplayMember = "Sectorname";
            this.cboMathang.ValueMember = "IdSectors";
            txtIdHH.ResetText();
            txtNameGood.ResetText();
            cboMathang.ResetText();
            txtUnit.ResetText();
            txtPrice.ResetText();
            txtSoLuong.ResetText();
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            int r = dvgGood.CurrentCell.RowIndex;
            string Id = dvgGood.Rows[r].Cells[0].Value.ToString();
            DialogResult tl =
                MessageBox.Show("Bạn chắc xóa không",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                BG.DeleteGoods(Id);
                MessageBox.Show("Xóa thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);


            }
            LoadGoodsData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtPrice.ResetText();
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.txtIdHH.ResetText();
            this.txtNameGood.ResetText();
            this.txtTimKiem.ResetText();
            this.txtUnit.ResetText();
            this.txtSoLuong.ResetText();
            dtp1.Value = DateTime.Today;
            dtp2.Value = DateTime.Today;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            DataTable find = BG.FindIdGoods(txtTimKiem.Text.ToString());
            dvgGood.DataSource = find;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadGoodsData();
            txtTimKiem.ResetText();
        }
    }
}
