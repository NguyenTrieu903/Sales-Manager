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
    public partial class frmDoiMK : Form
    {
        BussniessLogin BG = new BussniessLogin();
        public frmDoiMK()
        {
            InitializeComponent();
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            if (BG.validate(txtUsername.Text,txtOldPass.Text))
            {
                BG.UpdatePassword(txtUsername.Text, txtNewPass.Text);
                MessageBox.Show("Đổi mật khẩu thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu khong thành công",
                                    "Thành Công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }
        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMK_Load(object sender, EventArgs e)
        {

        }
    }
}
