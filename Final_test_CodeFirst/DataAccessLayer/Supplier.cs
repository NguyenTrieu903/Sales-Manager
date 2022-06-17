using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Supplier
    {
        public string Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string Idsectors { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
