using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using BussniessLogic;
namespace Final_test_CodeFirst
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new Initializer());
            AddData db = new AddData();
            db.Data();
            //Console.WriteLine("Success");
            //Console.ReadKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
        public static void addBill()
        {
            using (var context = new Context())
            {
                var sector = new Sector
                {
                    Idsectors = "MH1",
                    Sectorname = "Rau cu qua"
                };
                var goods = new Good
                {
                    Id = "HH1",
                    Idsectors = "MH1",
                    Goodsname = "Rau cai",
                    Price = 3000,
                    Unit = "Bo",
                    Productiondate = new DateTime(1992, 6, 7),
                    Shelflife = new DateTime(1992, 6, 7)
                };
                var goods_2 = new Good
                {
                    Id = "HH2",
                    Idsectors = "MH1",
                    Goodsname = "Ca rot",
                    Price = 10000,
                    Unit = "Cu",
                    Productiondate = new DateTime(1992, 6, 7),
                    Shelflife = new DateTime(1992, 6, 7)
                };
                sector.Goods.Add(goods);
                sector.Goods.Add(goods_2);
                context.Sectors.Add(sector);
                context.SaveChanges();
                var nv = new Employee
                {
                    Id = "NV1",
                    FullName = "Nguyen Van A",
                    Gender = "Nam",
                    DayofBirth = new DateTime(1992, 6, 7),
                    Address = "Binh dinh",
                    NumberPhone = "099252352",
                    Identitycard = "141412412412",
                    Position = "Bao ve",
                    Salary = 1000000
                };
                context.Employees.Add(nv);
                context.SaveChanges();
                var cus = new Customer
                {
                    Id = "KH1",
                    Name = "Truc",
                    NumberPhone = "141492144",
                    Address = "An nhon",
                    Gender = "Nu"
                };
                context.Customers.Add(cus);
                context.SaveChanges();
                var bill = new Bill
                {
                    Id = "1",
                    IdCus = "KH1",
                    IdEm = "NV1",
                    DateBill = new DateTime(2020, 6, 7),
                    Total = 40000
                };
                var billinfo_1 = new Billinfo
                {
                    Idbill = "1",
                    IdGoods = "HH1",
                    quantity = 1,
                    Unitprice = 5000,
                    discount = 20,
                    Intomoney = 50000
                };
                var billinfo_2 = new Billinfo
                {
                    Idbill = "1",
                    IdGoods = "HH2",
                    quantity = 4,
                    Unitprice = 3000,
                    discount = 10,
                    Intomoney = 50000
                };
                bill.Billinfoes.Add(billinfo_1);
                bill.Billinfoes.Add(billinfo_2);
                context.Bills.Add(bill); 
                context.SaveChanges();
            }
        }
    }
}
