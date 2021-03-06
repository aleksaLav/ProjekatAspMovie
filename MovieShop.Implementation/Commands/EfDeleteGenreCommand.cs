using EfDataAccess;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Exceptions;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace MovieApp.Implementation.Commands
{
    public class EfDeleteGenreCommand : IDeleteGenreCommand
    {
        private readonly MovieContext context;
        private readonly DeleteGenreValidator validator;

        public EfDeleteGenreCommand(MovieContext context, DeleteGenreValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 4;

        public string Name => "Ef delete genre";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var genre = context.Genres.Find(request);

            if(genre == null)
            {
                throw new EntityNotFoundException(request, typeof(Domain.Genre)); 
            }

            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }
}
