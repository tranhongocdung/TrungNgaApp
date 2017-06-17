using System;
using System.Data.Entity;
using MVCWeb.Core.EntityConfigs;

namespace MVCWeb.Core.Entities
{
    public interface IDbAppContext : IDisposable
    {
        
    }
    public class DbAppContext : DbContext, IDbAppContext
    {
        public DbAppContext()
            : base("name=TrungNgaDBConnectionString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DbAppContext>());
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BookInfo> BookInfos { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<CoachType> CoachTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLog> BookLogs { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportDirection> TransportDirections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new TransportDirectionMapping());
            modelBuilder.Configurations.Add(new TransportMapping());
            modelBuilder.Configurations.Add(new SeatMapping());
            modelBuilder.Configurations.Add(new CoachMapping());
            modelBuilder.Configurations.Add(new CoachTypeMapping());
            modelBuilder.Configurations.Add(new BookMapping());
            modelBuilder.Configurations.Add(new BookLogMapping());
            modelBuilder.Configurations.Add(new BookInfoMapping());

            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {

        }

    }
}