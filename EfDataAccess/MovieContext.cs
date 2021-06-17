using EfDataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess
{
    public class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=movies;Integrated Security=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ActorId });

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.Created = DateTime.Now;
                            e.Updated = null;
                            e.IsDeleted = false;
                            e.SoftDeleted = null;
                            break;
                        case EntityState.Modified:
                            e.Updated = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();  
        }

        #region DbSet
        public DbSet<User> Users { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReservation> MovieReservations { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }




        #endregion


    }
}
