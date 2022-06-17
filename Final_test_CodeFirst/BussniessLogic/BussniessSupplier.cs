using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessSupplier
    {
        Context context = new Context();
        Generality ge = new Generality();
        BussniessGoods BG = new BussniessGoods();
        public DataTable getSupplier()
        {
            var cuslist =
               (from p in context.Suppliers
                from q in context.Sectors
                where p.Idsectors == q.Idsectors
                select new { 
                    Id=p.Id,
                    SupplierName = p.SupplierName,
                    SupplierAddress = p.SupplierAddress,
                    NumberPhone = p.NumberPhone,
                    Email = p.Email,
                    Sectorname = q.Sectorname
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public DataTable FindIdSupplier(string id)
        {
            var cuslist =
               (from p in context.Suppliers
                from q in context.Sectors
                where p.Id==id && p.Idsectors == q.Idsectors
                select new
                {
                    Id = p.Id,
                    SupplierName = p.SupplierName,
                    SupplierAddress = p.SupplierAddress,
                    NumberPhone = p.NumberPhone,
                    Email = p.Email,
                    Sectorname = q.Sectorname
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public void DeleteSupplier(string Id)
        {
            var Staff = from s in context.Suppliers
                        where s.Id.Contains(Id)
                        select s;
            context.Suppliers.RemoveRange(Staff);
            context.SaveChanges();
        }
        public void AddSupplier(string Id, string SupplierName,
             string SupplierAddress, string NumberPhone, string Email, string IdSupplyItems)
        {
            string Idsector = BG.getIdSector(IdSupplyItems);
            Supplier sup = new Supplier();
            sup.Id = Id;
            sup.SupplierName = SupplierName;
            sup.SupplierAddress = SupplierAddress;
            sup.NumberPhone = NumberPhone;
            sup.Email = Email;
            sup.Idsectors = Idsector;
            context.Suppliers.Add(sup);
            context.SaveChanges();
        }
        public void UpdateSupplier(string Id, string SupplierName,
             string SupplierAddress, string NumberPhone, string Email, string IdSupplyItems)
        {
            string Idsector = BG.getIdSector(IdSupplyItems);
            Supplier sup = (from p in context.Suppliers
                            where p.Id == Id
                            select p).FirstOrDefault();

            sup.Id = Id;
            sup.SupplierName = SupplierName;
            sup.SupplierAddress = SupplierAddress;
            sup.NumberPhone = NumberPhone;
            sup.Email = Email;
            sup.Idsectors = Idsector;
            context.SaveChanges();
        }
    }
}
