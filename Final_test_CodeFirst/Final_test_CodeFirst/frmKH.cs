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
    public partial class frmKH : Form
    {
        private bool Sua = false;
        private DataTable dtC = new DataTable();
        BussniessCustomer bs = new BussniessCustomer();
        public frmKH()
        {
            InitializeComponent();
        }
        private void LoadCustomerData()
        {
            dtC = bs.getCustomer();
            dvgCustomer.DataSource = dtC;
        }
        private void frmKH1_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnReload.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTrove.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadCustomerData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dvgCustomer.CurrentCell.RowIndex;
            string MaKH = dvgCustomer.Rows[r].Cells[0].Value.ToString();
            Console.WriteLine(MaKH);
            DialogResult tl =
                MessageBox.Show("Bạn chắc xóa không",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                bs.DeleteCustomer(MaKH);
                MessageBox.Show("Xóa thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);


            }
            LoadCustomerData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.txtId.ReadOnly = true;
            this.groupBox1.Enabled = true;
            Sua = true;
            int r = dvgCustomer.CurrentCell.RowIndex;
            this.txtId.Text = dvgCustomer.Rows[r].Cells[0].Value.ToString();
            this.txtName.Text = dvgCustomer.Rows[r].Cells[1].Value.ToString();
            this.txtAddress.Text = dvgCustomer.Rows[r].Cells[3].Value.ToString();
            this.txtPhone.Text = dvgCustomer.Rows[r].Cells[2].Value.ToString();
            var gender = dvgCustomer.Rows[r].Cells[4].Value.ToString();
            if (gender == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextField txtMaKH
            this.txtId.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.txtId.ReadOnly = false;
            this.groupBox1.Enabled = true;
            Sua = false;
            // Xoa du lieu trong textbox
            txtAddress.ResetText();
            txtId.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            radNam.Checked = false;
            radNu.Checked = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var rad = "";
            if (radNam.Checked)
                rad = radNam.Text;
            else
                rad = radNu.Text;
            if (Sua)
            {
                DialogResult tl =
                MessageBox.Show("Bạn có muốn lưu những thay đổi này không?",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    bs.UpdateCustomer(txtId.Text, txtName.Text,
                           txtPhone.Text, txtAddress.Text, rad);
                    MessageBox.Show("Chỉnh sửa thành công!",
                        "Thành công!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadCustomerData();
                }

            }
            else
            {
                bs.AddCustomer(txtId.Text, txtName.Text,
                   txtPhone.Text, txtAddress.Text, rad);
                MessageBox.Show("Thêm thành công!",
                    "Thành công!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadCustomerData();
            }
            // Xoa du lieu trong textbox
            txtAddress.ResetText();
            txtId.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            radNam.Checked = false;
            radNu.Checked = false;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable find = bs.FindNumberPhone(txtTimKiem.Text);
            dvgCustomer.DataSource = find;
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Hide_Row_NULL()
        {
            for (int i = 0; i < dvgCustomer.Rows.Count - 1; i++)
            {
                if (dvgCustomer.Rows[i].Cells[2].Value.ToString() == " ")
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dvgCustomer.DataSource];
                    currencyManager1.SuspendBinding();
                    dvgCustomer.Rows[i].Visible = false;
                    currencyManager1.ResumeBinding();
                }

            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide_Row_NULL();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.txtAddress.ResetText();
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.txtId.ResetText();
            this.txtName.ResetText();
            this.txtPhone.ResetText();
            this.txtTimKiem.ResetText();
        }
    }
}
