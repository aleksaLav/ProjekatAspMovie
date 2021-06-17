using EfDataAccess;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace MovieShop.Implementation.Commands
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
