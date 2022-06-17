using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class Generality
    {
        public DataTable LINQResultToDataTable<T>(IEnumerable<T> LinqList)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (LinqList == null) return dt;
            foreach (T Record in LinqList)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public void addBill()
        {
            using (var context = new Context())
            {
                var sector = new Sector
                {
                    Idsectors = "MH1",
                    Sectorname = "Rau củ quả"
                };
                var sector_2 = new Sector
                {
                    Idsectors = "MH2",
                    Sectorname = "Đồ uống"
                };
                var supplier = new Supplier
                {
                    Id = "1",
                    SupplierName = "Thien Long",
                    SupplierAddress = "TPHCM",
                    NumberPhone = "0988011752",
                    Email = "123@gmail.com",
                    Idsectors = "MH1"
                };
                context.Suppliers.Add(supplier);
                var goods = new Good
                {
                    Id = "HH1",
                    Idsectors = "MH1",
                    Goodsname = "Rau cải",
                    Price = 5000,
                    Unit = "1 bó",
                    Productiondate = new DateTime(2022, 05, 10),
                    Shelflife = new DateTime(2022, 05, 17)
                };
                var goods_2 = new Good
                {
                    Id = "HH2",
                    Idsectors = "MH1",
                    Goodsname = "Cà rốt",
                    Price = 15000,
                    Unit = "1 kg",
                    Productiondate = new DateTime(2022, 05, 15),
                    Shelflife = new DateTime(2022, 05, 22)
                };
                var goods_3 = new Good
                {
                    Id = "HH4",
                    Idsectors = "MH2",
                    Goodsname = "Bia Heiniken",
                    Price = 500000,
                    Unit = "1 thùng",
                    Productiondate = new DateTime(2022, 01, 01),
                    Shelflife = new DateTime(2025, 01, 01)
                };
                var goods_4 = new Good
                {
                    Id = "HH9",
                    Idsectors = "MH2",
                    Goodsname = "Rượu Volka",
                    Price = 75000,
                    Unit = "1 chai",
                    Productiondate = new DateTime(2022, 04, 10),
                    Shelflife = new DateTime(2023, 04, 10)
                };
                sector.Goods.Add(goods);
                sector.Goods.Add(goods_2);
                sector_2.Goods.Add(goods_3);
                sector_2.Goods.Add(goods_4);
                //sector.Suppliers.Add(supplier);
                context.Sectors.Add(sector);
                context.Sectors.Add(sector_2);
                context.SaveChanges();
                var nv_1 = new Employee
                {
                    Id = "NV1",
                    FullName = "Lê Tuyết Nhung",
                    Gender = "Nữ",
                    DayofBirth = new DateTime(2000, 04, 05),
                    Address = "Phú Yên",
                    NumberPhone = "0912347521",
                    Identitycard = "113203458712",
                    Position = "Thu ngân",
                    Salary = 5000000
                };
                var nv_2 = new Employee
                {
                    Id = "NV2",
                    FullName = "Nguyễn Nhật Ánh",
                    Gender = "Nữ",
                    DayofBirth = new DateTime(1981, 12, 12),
                    Address = "Bình Định",
                    NumberPhone = "0382139843",
                    Identitycard = "123487900982",
                    Position = "Thu ngân",
                    Salary = 5000000
                };
                context.Employees.Add(nv_1);
                context.Employees.Add(nv_2);
                context.SaveChanges();
                var cus = new Customer
                {
                    Id = "KH2",
                    Name = "Truc",
                    NumberPhone = "0988011752",
                    Address = "An Nhơn",
                    Gender = "Nữ"
                };
                var cus_2 = new Customer
                {
                    Id = "KH1",
                    Name = "Phan Thùy Như",
                    NumberPhone = "0362152625",
                    Address = "Cần Thơ",
                    Gender = "Nữ"
                };
                context.Customers.Add(cus);
                context.Customers.Add(cus_2);
                context.SaveChanges();
                var bill = new Bill
                {
                    Id = "1",
                    IdCus = "KH1",
                    IdEm = "NV1",
                    DateBill = new DateTime(2020, 04, 11),
                    Total = 50000
                };
                var bill_2 = new Bill
                {
                    Id = "2",
                    IdCus = "KH2",
                    IdEm = "NV2",
                    DateBill = new DateTime(2022, 05, 28),
                    Total = 120000
                };
                var billinfo_1 = new Billinfo
                {
                    Idbill = "1",
                    IdGoods = "HH1",
                    quantity = 10,
                    Unitprice = 10000,
                    discount = 0,
                    Intomoney = 100000
                };
                var billinfo_2 = new Billinfo
                {
                    Idbill = "2",
                    IdGoods = "HH2",
                    quantity = 4,
                    Unitprice = 30000,
                    discount = 10,
                    Intomoney = 50000
                };
                bill.Billinfoes.Add(billinfo_1);
                bill_2.Billinfoes.Add(billinfo_2);
                context.Bills.Add(bill);
                context.Bills.Add(bill_2);
                context.SaveChanges();
            }
        }
    }
}
