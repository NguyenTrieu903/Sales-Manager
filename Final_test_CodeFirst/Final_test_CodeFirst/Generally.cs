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
namespace Final_test_CodeFirst
{
    public partial class Generally : Form
    {
        Context context = new Context();

        public Generally()
        {
            InitializeComponent();
        }

        private void Generally_Load(object sender, EventArgs e)
        {
            
            int DM = Convert.ToInt32(this.Text);
            try
            {
                switch (DM)
                {
                    case 1:
                        this.Text = "Danh mục nhân viên";
                        lblDanhMuc.Text = "Danh mục nhân viên";
                        var nv = (from s in context.Employees
                                  select new
                                  {
                                      Id = s.Id,
                                      FullName = s.FullName,
                                      Gender = s.Gender,
                                      DayofBirth = s.DayofBirth,
                                      Address = s.Address,
                                      NumberPhone = s.NumberPhone,
                                      Identitycard = s.Identitycard,
                                      Position = s.Position,
                                      Salary = s.Salary
                                  }).ToList();
                        dgvDanhMuc.DataSource = nv;
                        break;
                    case 2:
                        this.Text = "Danh mục hàng hóa";
                        lblDanhMuc.Text = "Danh mục hàng hóa";
                        var hh = (from h in context.Goods
                                  join s in context.Sectors on h.Idsectors equals s.Idsectors
                                  select new
                                  {
                                      Id = h.Id,
                                      Goodsname = h.Goodsname,
                                      Sectorname = s.Sectorname,
                                      Unit = h.Unit,
                                      Price = h.Price,
                                      Productiondate = h.Productiondate,
                                      Shelflife=h.Shelflife
                                  }).ToList();
                        dgvDanhMuc.DataSource = hh;
                        break;
                    case 3:
                        this.Text = "Danh mục khách hàng";
                        lblDanhMuc.Text = "Danh mục khách hàng";
                        var kh = (from k in context.Customers
                                  select new
                                  {
                                      Id = k.Id,
                                      Name = k.Name,
                                      NumberPhone = k.NumberPhone,
                                      Address = k.Address,
                                      Gender = k.Gender
                                  }).ToList();
                        dgvDanhMuc.DataSource = kh;
                        break;
                    case 4:
                        this.Text = "Danh mục nhà cung cấp";
                        lblDanhMuc.Text = "Danh mục nhà cung cấp";
                        var ncc=(from cc in context.Suppliers
                                 join s in context.Sectors on cc.Idsectors equals s.Idsectors
                                 select new
                                 {
                                     Id=cc.Id,
                                     SupplierName=cc.SupplierName,
                                     SupplierAddress=cc.SupplierAddress,
                                     NumberPhone=cc.NumberPhone,
                                     Email=cc.Email,
                                     IdSupplyitems=s.Sectorname
                                 }).ToList();

                        dgvDanhMuc.DataSource = ncc;
                        break;
                    case 5:
                        this.Text = "Danh mục hóa đơn";
                        lblDanhMuc.Text = "Danh mục hóa đơn";
                        var hd = (from d in context.Bills
                                  select new
                                  {
                                      Id = d.Id,
                                      IdCus = d.IdCus,
                                      IdEm = d.IdEm,
                                      DateBill = d.DateBill,
                                      Total = d.Total

                                  }).ToList();
                        dgvDanhMuc.DataSource = hd;
                        break;
                    case 6:
                        this.Text = "Danh mục chi tiết hóa đơn";
                        lblDanhMuc.Text = "Danh mục chi tiết hóa đơn";
                        var cthd = (from ct in context.Billinfoes
                                    select new
                                    {
                                        Idbill=ct.Idbill,
                                        IdGoods=ct.IdGoods,
                                        quantity=ct.quantity,
                                        Unitprice=ct.Unitprice,
                                        discount=ct.discount,
                                        Intomoney=ct.Intomoney
                                    }).ToList();
                        dgvDanhMuc.DataSource = cthd;
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
        private void btnTrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
