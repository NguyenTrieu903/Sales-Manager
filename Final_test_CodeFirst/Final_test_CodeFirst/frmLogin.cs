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
    public partial class frmLogin : Form
    {
        BussniessLogin BG = new BussniessLogin();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            if (BG.validate(txtUsername.Text, txtPassword.Text))
            {
                //this.Hide();
                f.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
