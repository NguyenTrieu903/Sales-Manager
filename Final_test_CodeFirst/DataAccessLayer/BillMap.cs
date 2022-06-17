using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class BillMap : EntityTypeConfiguration<Bill>
    {
        public BillMap()
        {
            Property(b => b.Id)
                .HasMaxLength(10)
                .IsRequired();
            //Property(b => b.IdCus)
            //    .HasMaxLength(10)
            //    .IsRequired();
            //Property(b => b.IdEm)
            //    .HasMaxLength(10)
            //    .IsRequired();
            Property(b => b.DateBill)
                .HasPrecision(10);

            HasRequired(t => t.Employee)
                .WithMany(c => c.Bills)
                .HasForeignKey(t => t.IdEm)
                   .WillCascadeOnDelete(true);

            HasRequired(t => t.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(t => t.IdCus)
                   .WillCascadeOnDelete(true);

            //HasMany(b=>b.Billinfoes)
            //    .WithRequired()
            //    .HasForeignKey(ph => ph.Idbill);
        }
    }
}
