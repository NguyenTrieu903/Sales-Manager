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
    public partial class frmNhanVien : Form
    {
        private bool Sua = false;
        private DataTable dtC = new DataTable();
        BussniessEmployee bs = new BussniessEmployee();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void LoadEmployeeData()
        {
            dtC = bs.getEmployee();
            dvgEmployee.DataSource = dtC;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            Sua = true;
            int r = dvgEmployee.CurrentCell.RowIndex;
            this.txtId.Text = dvgEmployee.Rows[r].Cells[0].Value.ToString();
            this.txtName.Text = dvgEmployee.Rows[r].Cells[1].Value.ToString();
            var gender = dvgEmployee.Rows[r].Cells[2].Value.ToString();
            //this.datetime.Value = Convert.ToDateTime(dvgEmployee.Rows[r].Cells[3].Value);
            this.datetime.Value = DateTime.Parse(dvgEmployee.Rows[r].Cells[3].Value.ToString());
            this.txtAddress.Text = dvgEmployee.Rows[r].Cells[4].Value.ToString();
            this.txtPhone.Text = dvgEmployee.Rows[r].Cells[5].Value.ToString();
            this.txtIdentity.Text = dvgEmployee.Rows[r].Cells[6].Value.ToString();
            this.txtPos.Text = dvgEmployee.Rows[r].Cells[7].Value.ToString();
            this.txtSalary.Text = dvgEmployee.Rows[r].Cells[8].Value.ToString();
            if (gender == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            this.btnLuu.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnHuy.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtId.Focus();
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
                    bs.UpdateEmployee(txtId.Text, txtName.Text, rad, datetime.Value, txtAddress.Text,
                   txtPhone.Text, txtIdentity.Text, txtPos.Text, txtSalary.Text);
                    MessageBox.Show("Chỉnh sửa thành công!",
                        "Thành công!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadEmployeeData();
                }

            }else
            {
                bs.AddEmployee(txtId.Text, txtName.Text, rad, datetime.Value, txtAddress.Text,
                       txtPhone.Text, txtIdentity.Text, txtPos.Text, txtSalary.Text);
                MessageBox.Show("Thêm thành công!",
                    "Thành công!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadEmployeeData();
            }
            // Xoa du lieu trong textbox
            txtAddress.ResetText();
            txtId.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            radNam.Checked = false;
            radNu.Checked = false;
            txtIdentity.ResetText();
            txtPos.ResetText();
            txtSalary.ResetText();
            datetime.Value = DateTime.Today;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnLuu.Enabled = false;
        }
        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnReload.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTrove.Enabled = true;
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            LoadEmployeeData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dvgEmployee.CurrentCell.RowIndex;
            string MaNV = dvgEmployee.Rows[r].Cells[0].Value.ToString();
            DialogResult tl =
                MessageBox.Show("Bạn chắc xóa không",
                                "Thông báo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                bs.DeleteEmployee(MaNV);
                MessageBox.Show("Xóa thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);


            }
            LoadEmployeeData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
            Sua = false; 
            // Xoa du lieu trong textbox
            txtAddress.ResetText();
            txtId.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            radNam.Checked = false;
            radNu.Checked = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            txtIdentity.ResetText();
            txtPos.ResetText();
            txtSalary.ResetText();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable find = bs.FindIdEmployee(txtTimKiem.Text);
            dvgEmployee.DataSource = find;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = false;
            this.btnLuu.Enabled = false;
            this.txtTimKiem.ResetText();
            this.txtId.ResetText();
            this.txtName.ResetText();
            this.txtPhone.ResetText();
            this.txtAddress.ResetText();
            this.txtSalary.ResetText();
            this.txtIdentity.ResetText();
            this.txtPos.ResetText();
        }
    }
}
