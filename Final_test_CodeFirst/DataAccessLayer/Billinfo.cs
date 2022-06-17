using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Billinfo
    {
        [Key]
        [Column(Order = 10)]
        public string Idbill { get; set; }
        [Key]
        [Column(Order = 20)]
        public string IdGoods { get; set; }
        public double quantity { get; set; }
        public Nullable<double> Unitprice { get; set; }
        public Nullable<int> discount { get; set; }
        public Nullable<double> Intomoney { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Good Good { get; set; }
    }
}
