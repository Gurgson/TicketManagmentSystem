using Microsoft.EntityFrameworkCore;
using TicketManagmentSystem.Server.Models;

namespace TicketManagmentSystem.Server.DataAcess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Address).IsRequired().HasMaxLength(200);
            builder.Property(l => l.City).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Region).IsRequired().HasMaxLength(100);
            builder.Property(l => l.ZipCode).IsRequired().HasMaxLength(20);
            builder.Property(l => l.Country).IsRequired().HasMaxLength(100);
            builder.Property(l => l.GridWidth).IsRequired();
            builder.Property(l => l.GridHeight).IsRequired();
        }
    }
}
