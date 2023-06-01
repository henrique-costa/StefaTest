using Microsoft.EntityFrameworkCore;
using Stefanini.Registration.Data.Configurations;
using Stefanini.Registration.Domain.Entities;

namespace Stefanini.Registration.Data
{
    public class StefaniniRegistrationContext : DbContext
    {
        public StefaniniRegistrationContext() {}
        public StefaniniRegistrationContext(DbContextOptions<StefaniniRegistrationContext> options) : base(options) {}

        public DbSet<Location> Locations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Domain.Entities.Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Location>(new LocationConfiguration().Configure);
            modelBuilder.Entity<Event>(new EventConfiguration().Configure);

            // one to many
            modelBuilder.Entity<Domain.Entities.Event>()
            .HasMany(e => e.Registrations) // Event can have many Registrations
            .WithOne(r => r.Event) // Registration belongs to one Event
            .HasForeignKey(r => r.EventId); // Foreign key property in Registration
        }

    }
}
