using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Registration.Domain.Entities;

namespace Stefanini.Registration.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasData(
                    new Location { Id = 1, City = "Horseshoe Bay", State = "Texas" },
                    new Location { Id = 2, City = "Moab", State = "Utah" },
                    new Location { Id = 3, City = "Gilford", State = "New Hampshire" },
                    new Location { Id = 4, City = "Las Vegas", State = "Nevada" }
                );
        }
    }
}
