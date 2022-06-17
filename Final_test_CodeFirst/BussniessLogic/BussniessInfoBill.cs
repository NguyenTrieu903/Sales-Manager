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
    public class BussniessInfoBill
    {
        Context context = new Context();
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
        public DataTable getMaHD()
        {
            var c = (from x in context.Bills
                     select new { Id = x.Id }).ToList();
            DataTable dt = LINQResultToDataTable(c);
            return dt;
        }
        public DataTable getInfoBill(string Id)
        {
            var y = (from d in context.Billinfoes
                     from dx in context.Sectors
                     join c in context.Goods on d.IdGoods equals c.Id
                     where c.Idsectors == dx.Idsectors && d.Idbill == Id
                     select new
                     {
                         Sectorname = dx.Sectorname,
                         Goodsname = c.Goodsname,
                         quanlity = d.quantity,
                         Price = c.Price,
                         discount = d.discount,
                         Intomoney = (d.quantity * c.Price) - (d.quantity * c.Price * d.discount / 100)
                     }).ToList();
            DataTable dtct = LINQResultToDataTable(y);
            return dtct;
        }
        public DataTable GeneralinforBill(string Id)
        {
            var x = (from d in context.Bills
                     join c in context.Customers on d.IdCus equals c.Id
                     join s in context.Employees on d.IdEm equals s.Id
                     where d.Id == Id
                     select new
                     {
                         Id = d.Id,
                         Idcus = c.Id,
                         IdEm = s.Id,
                         FullName = s.FullName,
                         Name = c.Name,
                         DateBill = d.DateBill,
                         Address = c.Address,
                         NumberPhone = c.NumberPhone,
                     }).ToList();
            DataTable dt = LINQResultToDataTable(x);
            return dt;
        }
        public double getTotalMoney(String Id)
        {
            DataTable dt = getInfoBill(Id);
            double total = dt.AsEnumerable().Sum(r => r.Field<double>("Intomoney"));
            return total;
        }
        public DataTable getSector()
        {
            var x = (from d in context.Sectors
                     select d).ToList();
            DataTable dt = LINQResultToDataTable(x);
            return dt;
        }
        public DataTable getGoodname(string sectorname)
        {
            var x = (from d in context.Goods
                     from q in context.Sectors
                     where q.Sectorname == sectorname && q.Idsectors == d.Idsectors
                     select new
                     {
                         Goodsname = d.Goodsname
                     }).ToList();
            DataTable dt = LINQResultToDataTable(x);
            return dt;
        }
        public string getMaHH(string Tenhang)
        {
            string MaMH = "";
            var z = (from p in context.Goods
                     where p.Goodsname == Tenhang
                     select new
                     {
                         Id = p.Id
                     }).ToList();
            DataTable dt = LINQResultToDataTable(z);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    MaMH = row[0].ToString();
                }
            }
            return MaMH;
        }
        public string getPrice(string goodname)
        {
            string gia = " ";
            var g = (from p in context.Goods
                     where p.Goodsname == goodname
                     select new
                     {
                         Price = p.Price
                     }).ToList();
            DataTable dt = LINQResultToDataTable(g);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    gia = row[0].ToString();
                }
            }
            return gia;
        }
        public void AddBillInfo(string Mabill, string Tenhang, float Dongia, float Soluong, int Giamgia)
        {
            string MaMH = getMaHH(Tenhang);
            Billinfo BI = new Billinfo();
            BI.Idbill = Mabill;
            BI.IdGoods = MaMH;
            BI.Unitprice = Dongia;
            BI.quantity = Soluong;
            BI.discount = Giamgia;
            BI.Intomoney = (BI.quantity * BI.Unitprice) - (BI.quantity * BI.Unitprice * BI.discount / 100);
            context.Billinfoes.Add(BI);
            context.SaveChanges();
        }
        public void UpdateBillInfo(string Mabill, string Tenhang, float Dongia, float Soluong, int Giamgia)
        {
            string MaMH = getMaHH(Tenhang);
            Billinfo bi = (from p in context.Billinfoes
                           where p.Idbill == Mabill && p.IdGoods == MaMH
                           select p).First();
            bi.Idbill = Mabill;
            bi.IdGoods = MaMH;
            bi.Unitprice = Dongia;
            bi.quantity = Soluong;
            bi.discount = Giamgia;
            bi.Intomoney = (bi.quantity * bi.Unitprice) - (bi.quantity * bi.Unitprice * bi.discount / 100);
            context.SaveChanges();
        }
        public void DeleteBillInfo(string MaHH , string Id)
        {
                var pf = (from p in context.Billinfoes
                          where p.Idbill == Id && p.IdGoods == MaHH
                          select p).FirstOrDefault();
                context.Billinfoes.Remove(pf);
                context.SaveChanges();
        }
        public int getSoLuongHH (string idb , string idg)
        {
            int sl = 0;
            var g = (from p in context.Billinfoes
                     where p.Idbill == idb && p.IdGoods==idg
                     select new
                     {
                         quantity=p.quantity
                     }).ToList();
            DataTable dt = LINQResultToDataTable(g);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    sl = int.Parse(row[0].ToString());
                }
            }
            return sl;
        }
        public void updateSL_2(string name, int amount, int soluong)
        {
            Good hh = (from g in context.Goods
                       where g.Goodsname == name
                       select g).First();
            hh.amount = amount + soluong;
            context.SaveChanges();
        }
    }
}
