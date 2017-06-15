using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.EntityConfigs
{
    public class BookLogMapping : EntityTypeConfiguration<BookLog>
    {
        public BookLogMapping()
        {
            ToTable("BookLog");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(o => o.BookInfo).WithMany(o => o.BookLogs).HasForeignKey(o => o.BookInfoId);
            HasRequired(o => o.User).WithMany(o => o.BookLogs).HasForeignKey(o => o.UserId);
        }
    }
}