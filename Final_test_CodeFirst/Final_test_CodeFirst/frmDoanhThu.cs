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
    public partial class frmDoanhThu : Form
    {
        BussniessDoanhThu BD = new BussniessDoanhThu();
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            dgvHDon.DataSource = BD.getHD();
            txtdoanhthu.Text = BD.getTotalMoney().ToString();
        }

        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
