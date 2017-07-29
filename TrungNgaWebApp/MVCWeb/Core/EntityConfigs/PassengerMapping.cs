using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MVCWeb.Core.Entities;

namespace MVCWeb.Core.EntityConfigs
{
    public class PassengerMapping : EntityTypeConfiguration<Passenger>
    {
        public PassengerMapping()
        {
            ToTable("Passenger");
            HasKey(o => o.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}