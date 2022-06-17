using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            Property(c => c.Id)
                .HasMaxLength(10)
                .IsRequired();
            Property(c => c.Name)
                .HasMaxLength(30)
                .IsUnicode(true);
            Property(c => c.NumberPhone)
                .HasMaxLength(12);
            Property(c => c.Address)
                .HasMaxLength(30)
                .IsUnicode(true);
            Property(c => c.Gender)
                .HasMaxLength(3)
                .IsUnicode(true);
            //HasMany(c => c.Bills)
            //    .WithRequired()
            //    .HasForeignKey(p => p.IdCus);
        }
    }
}
