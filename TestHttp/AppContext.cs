using Microsoft.EntityFrameworkCore;

namespace TestHttp
{
    public class AppContext : DbContext
    {
        public DbSet<DataModel> Data { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        public AppContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=password");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataModel>()
                .HasKey(o => o.Id);
        }

    }
}
