using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.EntityConfigs
{
    public class TicketMapping : EntityTypeConfiguration<Ticket>
    {
        public TicketMapping()
        {
            ToTable("Ticket");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(o => o.Transport).WithMany(o => o.Tickets).HasForeignKey(o => o.TransportId);
            HasRequired(o => o.Seat).WithMany(o => o.Tickets).HasForeignKey(o => o.SeatId);
            HasRequired(o => o.CreatedBy).WithMany(o => o.Tickets).HasForeignKey(o => o.CreatedById);
            HasOptional(o => o.Passenger).WithMany(o => o.Tickets).HasForeignKey(o => o.PassengerId);
            HasOptional(o => o.PickUpLocation).WithMany(o => o.Tickets).HasForeignKey(o => o.PickUpLocationId);
        }
    }
}