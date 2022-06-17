using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class GoodMap : EntityTypeConfiguration<Good>
    {
        public GoodMap()
        {
            Property(g => g.Id)
                .HasMaxLength(10)
                .IsRequired();
            Property(g => g.Goodsname)
                  .HasMaxLength(30)
                  .IsUnicode(true)
                  .IsRequired();
            Property(g => g.Unit)
                .HasMaxLength(10)
                .IsUnicode(true);
            Property(g => g.Productiondate)
                .HasPrecision(10);
            Property(g => g.Shelflife)
                .HasPrecision(10);

            HasRequired(t => t.Sector)
                .WithMany(c => c.Goods)
                .HasForeignKey(t => t.Idsectors)
                   .WillCascadeOnDelete(false);
            //HasMany(g => g.Billinfoes)
            //    .WithRequired()
            //    .HasForeignKey(ph => ph.IdGoods);
        }
    }
}
