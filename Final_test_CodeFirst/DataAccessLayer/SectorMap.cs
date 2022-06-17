using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class SectorMap : EntityTypeConfiguration<Sector>
    {
        public SectorMap()
        {
            HasKey(t => t.Idsectors);
            //Property(s => s.Idsectors) 
            //    .HasMaxLength(10)
            //    .IsRequired()
            //    .IsUnicode(true);

            Property(s => s.Sectorname)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(true);

            //HasMany(s => s.Goods)
            //    .WithRequired()
            //    .HasForeignKey(ph => ph.Idsectors);
        }
    }
}
