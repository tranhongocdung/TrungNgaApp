using System;
using System.Data.Entity;
using MVCWeb.AppDataLayer.EntityConfigs;

namespace MVCWeb.AppDataLayer.Entities
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
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLog> BookLogs { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportDirection> TransportDirections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.Configurations.Add(new BookMapping());

            base.OnModelCreating(modelBuilder);

        }

        public new void Dispose()
        {

        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}