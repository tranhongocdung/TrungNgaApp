using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.EntityConfigs
{
    public class TicketChangeLogMapping : EntityTypeConfiguration<TicketChangeLog>
    {
        public TicketChangeLogMapping()
        {
            ToTable("TicketChangeLog");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(o => o.Ticket).WithMany(o => o.TicketChangeLogs).HasForeignKey(o => o.TicketId);
            HasRequired(o => o.User).WithMany(o => o.TicketChangeLogs).HasForeignKey(o => o.UserId);
        }
    }
}