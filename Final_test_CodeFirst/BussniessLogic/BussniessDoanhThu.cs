using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BussniessLogic
{
    public class BussniessDoanhThu
    {
        Context context = new Context();
        Generality ge = new Generality();
        public DataTable getHD()
        {
            var cuslist =
               (from p in context.Bills
                select new { 
                    Id=p.Id,
                    IdCus=p.IdCus,
                    IdEm=p.IdEm,
                    DateBill=p.DateBill,
                    Total=p.Total
                }).ToList();
            DataTable dt = ge.LINQResultToDataTable(cuslist);
            return dt;
        }
        public double getTotalMoney()
        {
            DataTable dt = getHD();
            double total = dt.AsEnumerable().Sum(r => r.Field<double>("Total"));
            return total;
        }
    }
}
