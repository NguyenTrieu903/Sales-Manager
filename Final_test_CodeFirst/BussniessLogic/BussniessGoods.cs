using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessGoods
    {
        Context context = new Context();
        Generality ge = new Generality();
        public DataTable getHangHoa()
        {
            var cuslist =
               (from p in context.Goods
                from q in context.Sectors
                where p.Idsectors == q.Idsectors
                select new
                {
                    Id = p.Id,
                    Goodsname = p.Goodsname,
                    Sectorname = q.Sectorname,
                    Unit = p.Unit,
                    Price = p.Price,
                    Productiondate = p.Productiondate,
                    Shelflife = p.Shelflife,
                    amount = p.amount
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public DataTable FindIdGoods(string id)
        {
            var cuslist =
               (from p in context.Goods
                from q in context.Sectors
                where p.Id == id && p.Idsectors == q.Idsectors
                select new
                {
                    Id = p.Id,
                    Goodsname = p.Goodsname,
                    Sectorname = q.Sectorname,
                    Unit = p.Unit,
                    Price = p.Price,
                    Productiondate = p.Productiondate,
                    Shelflife = p.Shelflife,
                    amount = p.amount
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public void DeleteGoods(string IdGoods)
        {
            var goods = from s in context.Goods
                        where s.Id.Contains(IdGoods)
                        select s;
            context.Goods.RemoveRange(goods);
            context.SaveChanges();
        }
        public string getIdSector(string sectorname)
        {
            string res = " ";
            var g = (from p in context.Sectors
                     where p.Sectorname == sectorname
                     select new
                     {
                         Idsectors = p.Idsectors
                     }).ToList();
            DataTable dt = ge.LINQResultToDataTable(g);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    res = row[0].ToString();
                }
            }
            return res;
        }
        public void AddGoods(string Id, string GoodsName,
             string NameProduct, string Unit, string Price, DateTime Productiondate, DateTime Shelfilife, int soluong)
        {
            string Idsectors = getIdSector(NameProduct);
            Good gds = new Good();
            gds.Id = Id;
            gds.Goodsname = GoodsName;
            gds.Idsectors = Idsectors;
            gds.Unit = Unit;
            gds.Price = Convert.ToDouble(Price);
            gds.Productiondate = Productiondate;
            gds.Shelflife = Shelfilife;
            gds.amount = soluong;
            context.Goods.Add(gds);
            context.SaveChanges();
        }
        public void UpdateGoods(string Id, string GoodsName,
             string NameProduct, string Unit, string Price, DateTime Productiondate, DateTime Shelfilife, int soluong)
        {
            string Idsectors = getIdSector(NameProduct);
            Good gds = (from p in context.Goods
                        where p.Id == Id
                        select p).FirstOrDefault();

            gds.Id = Id;
            gds.Goodsname = GoodsName;
            gds.Idsectors = Idsectors;
            gds.Unit = Unit;
            gds.Price = Convert.ToDouble(Price);
            gds.Productiondate = Productiondate;
            gds.Shelflife = Shelfilife;
            gds.amount = soluong;
            context.SaveChanges();
        }
    }
}
