using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.Billinfoes = new HashSet<Billinfo>();
        }

        public string Id { get; set; }
        public string Goodsname { get; set; }
        public string Idsectors { get; set; }
        public string Unit { get; set; }
        public int amount { get; set; }
        public double Price { get; set; }
        public Nullable<System.DateTime> Productiondate { get; set; }
        public Nullable<System.DateTime> Shelflife { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Billinfo> Billinfoes { get; set; }
        public Sector Sector { get; set; }
    }
}
