using EfDataAccess;
using FluentValidation;
using MovieShop.Application.Commands;
using MovieShop.Application.Exceptions;
using MovieShop.Domain;
using MovieShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Commands
{
    public class EfDeleteMovieCommand : IDeleteMovieCommand
    {
        private readonly MovieContext context;
        private readonly DeleteMovieValidator validator;

        public EfDeleteMovieCommand(MovieContext context, DeleteMovieValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 21;

        public string Name => "Ef delete movie";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var movie = context.Movies.Find(request);

            if (movie == null)
            {
                throw new EntityNotFoundException(request, typeof(Movie));
            }

            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
