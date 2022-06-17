using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            Property(a => a.Username)
                .HasMaxLength(30)
                .IsRequired();
            Property(a => a.Password)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
