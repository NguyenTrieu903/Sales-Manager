using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            HasKey(s=>s.Id);
            Property(s => s.SupplierName)
                .IsRequired()
                .HasMaxLength(30);
            Property(s => s.SupplierAddress)
                .IsRequired()
                .HasMaxLength(30);

            Property(s => s.NumberPhone)
                .HasMaxLength(12);
            Property(s => s.Email)
                .HasMaxLength(30);
            HasRequired(t => t.Sector)
                .WithMany(c => c.Suppliers)
                .HasForeignKey(t => t.Idsectors);
        }
    }
}
