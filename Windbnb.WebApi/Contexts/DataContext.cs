using Windbnb.WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Windbnb.WebApi.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<RentalHistory> RentalHistories { get; set; }

        public DataContext(DbContextOptions<DataContext>
            options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Apartment>().HasOne<Owner>(e => e.Owner)
                .WithMany(d => d.Apartments)
                .HasForeignKey(e => e.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}