using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Dto;
using MovieApp.Application.Exceptions;
using MovieApp.Application.Queries;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Implementation.Queries
{
    public class EfGetOneMovieQuery : IGetOneMovieQuery
    {
        private readonly MovieContext context;

        public EfGetOneMovieQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 20;

        public string Name => "Ef get one movie";

        public MovieDtoShow Execute(int search)
        {
            var movie = context.Movies.Find(search);

            if (movie == null)
                throw new EntityNotFoundException(search, typeof(Movie));

            var movieQuery = context.Movies
                .Include(m => m.Director)
                .Include(m => m.ActorsLinks)
                .ThenInclude(a=>a.Actor)
                .Include(m => m.GenresLinks)
                .ThenInclude(g=>g.Genre)
                .Where(m => m.Id == search)
                .FirstOrDefault();

            var movieDto = new MovieDtoShow
            {
                Title = movie.Title,
                OnStock = movie.OnStock,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                RuntimeMinutes = movie.RuntimeMinutes,
                Actors = movie.ActorsLinks.Select(x => new ActorDto
                {
                    Id = x.ActorId,
                    FirstName = x.Actor.FirstName,
                    LastName = x.Actor.LastName
                }).ToList(),
                Director = new UpdateDirectorDto { Id = movie.Director.Id, FirstName = movie.Director.FirstName, LastName = movie.Director.LastName },
                Genres = movie.GenresLinks.Select(x => new GenreDto
                {
                    Id = x.GenreId,
                    Name = x.Genre.Name
                }).ToList()
            };

            return movieDto;
        }
    }
}
