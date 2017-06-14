using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.EntityConfigs
{
    public class TransportMapping : EntityTypeConfiguration<Transport>
    {
        public TransportMapping()
        {
            ToTable("Transport");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(o => o.Coach).WithMany(o => o.Transports).HasForeignKey(o => o.CoachId);
            HasRequired(o => o.Driver).WithMany(o => o.TransportsForDriver).HasForeignKey(o => o.DriverId);
            HasOptional(o => o.Assistant).WithMany(o => o.TransportsForAssistant).HasForeignKey(o => o.AssistantId);
            HasRequired(o => o.TransportDirection).WithMany(o => o.Transports).HasForeignKey(o => o.TransportDirectionId);
        }
    }
}