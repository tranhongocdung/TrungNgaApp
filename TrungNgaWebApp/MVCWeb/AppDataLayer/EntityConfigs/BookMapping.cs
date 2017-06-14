using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.AppDataLayer.Entities;

namespace MVCWeb.AppDataLayer.EntityConfigs
{
    public class BookMapping : EntityTypeConfiguration<Book>
    {
        public BookMapping()
        {
            ToTable("Book");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);;
            HasRequired(o => o.Transport).WithMany(o => o.Books).HasForeignKey(o => o.TransportId);
            HasRequired(o => o.Seat).WithMany(o => o.Books).HasForeignKey(o => o.SeatId);
            HasOptional(o => o.BookInfo).WithMany(o => o.Books).HasForeignKey(o => o.BookInfoId);
        }
    }
}