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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ExcelDataReader;

namespace Final_test_CodeFirst
{
    public partial class frmChitietHD : Form
    {
        //Context context = new Context();
        BussniessInfoBill LB = new BussniessInfoBill();
        BussniessBill NB = new BussniessBill();
        BussniessBill Lbn = new BussniessBill();
        private bool Them = true;
        public frmChitietHD()
        {
            InitializeComponent();
        }
        private void frmChitietHD_Load(object sender, EventArgs e)
        {
            this.txtMaHD.ReadOnly = true;
            this.txtMaNV.ReadOnly = true;
            this.txtTenNV.ReadOnly = true;
            this.txtMaKH.ReadOnly = true;
            this.txtTenKH.ReadOnly = true;
            this.txtDiachi.ReadOnly = true;
            this.txtDienthoai.ReadOnly = true;
            this.grbinfo.Enabled = true;
            this.btnTimkiem.Enabled = true;
            DataTable dt = LB.getMaHD();
            cboMaHD.DataSource = dt;
            cboMaHD.DisplayMember = "Id";
            cboMaHD.ValueMember = "Id";

        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.grbinfo.Enabled = true;
            string Id = cboMaHD.Text.ToString();
            DataTable dt = LB.GeneralinforBill(Id);
            DataTable dtinfo = LB.getInfoBill(Id);
            dgvChitietHD.DataSource = dtinfo;
            txtTongTien.Text = LB.getTotalMoney(Id).ToString();
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    txtMaHD.Text = row[0].ToString();
                    txtMaKH.Text = row[1].ToString();
                    txtMaNV.Text = row[2].ToString();
                    txtTenNV.Text = row[3].ToString();
                    txtTenKH.Text = row[4].ToString();
                    string d = row[5].ToString();
                    DateTime d1 = Convert.ToDateTime(d);
                    dtp1.Value = d1;
                    txtDiachi.Text = row[6].ToString();
                    txtDienthoai.Text = row[7].ToString();
                }
            }
        }
        public static int soluongHH = 0;
        public static int soluongTrongkho = 0;
        public static int demSua = 0;
        private void cboMathang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTenhang.DataSource = LB.getGoodname(cboMathang.Text.ToString());
            this.cboTenhang.DisplayMember = "Goodsname";
        }
        private void cboTenhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtDongia.Text = LB.getPrice(this.cboTenhang.Text.ToString());
        }
        private void cboGiamgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtThanhtien.Text = ((float.Parse(txtDongia.Text.ToString()) * float.Parse(txtSoluong.Text.ToString())) -
                (float.Parse(txtDongia.Text.ToString()) * float.Parse(txtSoluong.Text.ToString()) * int.Parse(cboGiamgia.Text.ToString()) / 100)).ToString();
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
        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
