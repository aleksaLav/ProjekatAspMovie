using EfDataAccess;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Domain;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using AutoMapper;

namespace MovieApp.Implementation.Commands
{
    public class EfCreateMovieCommand : ICreateMovieCommand
    {

        private readonly MovieContext context;
        private readonly AddMovieValidator validator;
        private readonly IMapper _mapper;

        public EfCreateMovieCommand(MovieContext context, AddMovieValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Ef create movie";

        public void Execute(MovieDto request)
        {
            validator.ValidateAndThrow(request);

            var movie = _mapper.Map<Movie>(request);

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
