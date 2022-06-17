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
    public partial class frmTaoTK : Form
    {
        BussniessLogin BG = new BussniessLogin();
        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            BG.AddAccount(txtUsername.Text, txtPassword.Text, txtDisplayname.Text);
            MessageBox.Show("Tạo tài khoản thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
