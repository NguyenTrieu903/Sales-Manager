using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Bills = new HashSet<Bill>();
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DayofBirth { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string Identitycard { get; set; }
        public string Position { get; set; }
        public Nullable<int> Salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
