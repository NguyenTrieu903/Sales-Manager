using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace DataAccessLayer
{
    public class BillinfoMap : EntityTypeConfiguration<Billinfo>
    {
        public BillinfoMap()
        {
            //HasKey(t => t.Idbill);
            //HasKey(t => t.IdGoods);

            HasRequired(t => t.Good)
                .WithMany(c => c.Billinfoes)
                .HasForeignKey(t => t.IdGoods)
                .WillCascadeOnDelete(true);

            HasRequired(t => t.Bill)
                .WithMany(c => c.Billinfoes)
                .HasForeignKey(t => t.Idbill)
                .WillCascadeOnDelete(true);
        }
    }
}
