using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Registration.Domain.Entities;

namespace Stefanini.Registration.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(x => x.Location).WithMany().HasForeignKey(x => x.EventLocationId);

            builder.HasData(
                    new Event { Id = 1, EventLocationId = 1, AvailableSeats = 5, Name = "Texas Event", Description = "ADVENTURE IS BIGGER IN TEXAS" },
                    new Event { Id = 2, EventLocationId = 2, AvailableSeats = 5, Name = "Moab Event", Description = "MIGHT AS WELL BE DRIVING ON MARS" },
                    new Event { Id = 3, EventLocationId = 3, AvailableSeats = 5, Name = "New Hampshire Event", Description = "OVER RUGGED HILLS & THROUGH DENSE WOODS" },
                    new Event { Id = 4, EventLocationId = 4, AvailableSeats = 5, Name = "Nevada Event", Description = "UNFORGIVING ROCKY DESERT LANDCAPE" }
                );
        }
    }
}
