using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.ReleaseDate).IsRequired();
            builder.Property(m => m.OnStock).IsRequired();
            builder.Property(m => m.RuntimeMinutes).IsRequired();

            builder.HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.GenresLinks)
                .WithOne(mg => mg.Movie).HasForeignKey(mg=>mg.MovieId);

            builder.HasMany(m => m.MovieReservations)
                .WithOne(mr => mr.Movie).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
