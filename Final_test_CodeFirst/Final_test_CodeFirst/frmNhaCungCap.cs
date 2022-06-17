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
    public partial class frmNhaCungCap : Form
    {
        BussniessSupplier BS = new BussniessSupplier();
        private bool Sua = false;
        private DataTable dtC = new DataTable();
        BussniessInfoBill BF = new BussniessInfoBill();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void LoadSupplier()
        {
            dtC = BS.getSupplier();
            dvgSupplier.DataSource = dtC;
        }
        private void frmNhaCungCap_1_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnReload.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTrove.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadSupplier();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dvgSupplier.CurrentCell.RowIndex;
            string Id = dvgSupplier.Rows[r].Cells[0].Value.ToString();

            DialogResult tl =
                MessageBox.Show("Bạn chắc xóa không",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                BS.DeleteSupplier(Id);
                MessageBox.Show("Xóa thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);


            }
            LoadSupplier();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.txtIdNCC.ReadOnly = true;
            this.cboMathang.DataSource = BF.getSector();
            this.cboMathang.DisplayMember = "Sectorname";
            this.cboMathang.ValueMember = "IdSectors";
            this.groupBox1.Enabled = true;
            Sua = true;
            int r = dvgSupplier.CurrentCell.RowIndex;
            this.txtIdNCC.Text = dvgSupplier.Rows[r].Cells[0].Value.ToString();
            this.txtNameSup.Text = dvgSupplier.Rows[r].Cells[1].Value.ToString();
            this.txtAddress.Text = dvgSupplier.Rows[r].Cells[2].Value.ToString();
            this.txtPhone.Text = dvgSupplier.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text = dvgSupplier.Rows[r].Cells[4].Value.ToString();
            this.cboMathang.Text = dvgSupplier.Rows[r].Cells[5].Value.ToString();
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextField txtMaKH
            this.txtIdNCC.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtIdNCC.ReadOnly = false;
            this.groupBox1.Enabled = true;
            Sua = false;
            this.cboMathang.DataSource = BF.getSector();
            this.cboMathang.DisplayMember = "Sectorname";
            this.cboMathang.ValueMember = "IdSectors";
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            // Xoa du lieu trong textbox
            txtIdNCC.ResetText();
            txtNameSup.ResetText();
            txtAddress.ResetText();
            txtPhone.ResetText();
            txtEmail.ResetText();
            cboMathang.ResetText();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            if (Sua)
            {
                DialogResult tl =
                MessageBox.Show("Bạn có muốn lưu những thay đổi này không?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    BS.UpdateSupplier(txtIdNCC.Text, txtNameSup.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, cboMathang.Text);
                    MessageBox.Show("Chỉnh sửa thành công!",
                        "Thành công!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadSupplier();
                }

            }
            else
            {
                BS.AddSupplier(txtIdNCC.Text, txtNameSup.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, cboMathang.Text);
                MessageBox.Show("Thêm thành công!",
                    "Thành công!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadSupplier();
            }
            // Xoa du lieu trong textbox
            txtIdNCC.ResetText();
            txtNameSup.ResetText();
            txtAddress.ResetText();
            txtPhone.ResetText();
            txtEmail.ResetText();
            cboMathang.ResetText();
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            //this.groupBox1.Enabled = true;
            txtIdNCC.ResetText();
            txtNameSup.ResetText();
            txtAddress.ResetText();
            txtPhone.ResetText();
            txtEmail.ResetText();
            cboMathang.ResetText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            DataTable find = BS.FindIdSupplier(txtTimKiem.Text.ToString());
            dvgSupplier.DataSource = find;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadSupplier();
            txtTimKiem.ResetText();
        }
    }
}
