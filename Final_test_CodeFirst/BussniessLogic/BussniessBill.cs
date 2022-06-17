using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLogic
{
    public class BussniessBill
    {
        Context context = new Context();
        BussniessInfoBill BB = new BussniessInfoBill();
        public DataTable getMaNV()
        {
            var c = (from x in context.Employees
                     select new { Id = x.Id }).ToList();
            DataTable dt = BB.LINQResultToDataTable(c);
            return dt;
        }
        public string getTenNV(string Manv)
        {
            string ten = " ";
            var t = (from p in context.Employees
                     where p.Id == Manv
                     select new
                     {
                         FullName = p.FullName
                     }).ToList();
            DataTable dt = BB.LINQResultToDataTable(t);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    ten = row[0].ToString();
                }
            }
            return ten;
        }
        public void AddKH(string Id, string numberphone)
        {
            Customer cs = new Customer();
            cs.Id = Id;
            cs.NumberPhone = numberphone;
            context.Customers.Add(cs);
            context.SaveChanges();
        }
        public void AddBill(string Id ,string IdCus , string IdEm , DateTime DateBill , float total)
        {
            Bill b = new Bill();
            b.Id = Id;
            b.IdCus = IdCus;
            b.IdEm = IdEm;
            b.DateBill = DateBill;
            b.Total = total;
            context.Bills.Add(b);
            context.SaveChanges();
        }
        public void updateBill(string Id, float tongtien)
        {
            Bill bi = (from p in context.Bills
                       where p.Id == Id
                       select p).First();
            bi.Total = tongtien;
            context.SaveChanges();
        }
        public void DeleteBill(string id)
        {
                var pf = (from p in context.Bills
                          where p.Id == id
                          select p).FirstOrDefault();
                context.Bills.Remove(pf);
                context.SaveChanges();
        }
        public void updateSL(string name , int amount,int soluong)
        {
            Good hh = (from g in context.Goods
                       where g.Goodsname == name
                       select g).First();
            hh.amount = amount - soluong;
            context.SaveChanges();
        }
        public int getSL (string goodname)
        {
            Good hh = (from g in context.Goods
                       where g.Goodsname == goodname
                       select g).FirstOrDefault();
            int res = hh.amount;
            return res;
        }
    }
}
