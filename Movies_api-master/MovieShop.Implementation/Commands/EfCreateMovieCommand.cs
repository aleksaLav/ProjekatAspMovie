using EfDataAccess;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Domain;
using MovieShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace MovieShop.Implementation.Commands
{
    public class EfCreateMovieCommand : ICreateMovieCommand
    {

        private readonly MovieContext context;
        private readonly AddMovieValidator validator;

        public EfCreateMovieCommand(MovieContext context, AddMovieValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 6;

        public string Name => "Ef create movie";

        public void Execute(MovieDto request)
        {
            validator.ValidateAndThrow(request);

            var movie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate,
                OnStock = request.OnStock,
                RuntimeMinutes = request.RuntimeMinutes,
                DirectorId = request.DirectorId
            };

            foreach (var item in request.Genres)
            {
                var genre = context.Genres.Find(item.Id);

                movie.GenresLinks.Add(new MovieGenre { Genre = genre, Movie = movie });
            }
            foreach (var item in request.Actors)
            {
                var actor = context.Actors.Find(item.Id);

                movie.ActorsLinks.Add(new MovieActor { Movie = movie, Actor = actor });
            }

            context.Movies.Add(movie);
            context.SaveChanges();
        }
    }
}
