using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(g => g.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(g => g.Name).IsUnique();

            builder.HasMany(g => g.MovieLinks)
                .WithOne(mg => mg.Genre).HasForeignKey(mg => mg.GenreId);
        }
    }
}
