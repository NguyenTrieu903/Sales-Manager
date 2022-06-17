using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            Property(e => e.Id)
                .HasMaxLength(10)
                .IsRequired();
            Property(e => e.FullName)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            Property(e => e.Gender)
                 .HasMaxLength(3)
                 .IsUnicode(true)
                 .IsRequired();
            Property(e => e.DayofBirth)
                .HasPrecision(10);
            Property(e => e.Address)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);
            Property(e => e.NumberPhone)
                .HasMaxLength(12)
                .IsRequired();
            Property(e => e.Identitycard)
                .HasMaxLength(12)
                .IsRequired();
            Property(e => e.Position)
                .HasMaxLength(12)
                .IsRequired()
                .IsUnicode(true);

            //HasMany(e => e.Bills)
            //    .WithRequired()
            //    .HasForeignKey(ph => ph.IdEm);
                
        }
    }
}
