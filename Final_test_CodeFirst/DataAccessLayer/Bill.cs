using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.Billinfoes = new HashSet<Billinfo>();
        }
        //[Key]
        public string Id { get; set; }
        public string IdCus { get; set; }
        public string IdEm { get; set; }
        public Nullable<System.DateTime> DateBill { get; set; }
        public Nullable<double> Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Billinfo> Billinfoes { get; set; }
    }
}
