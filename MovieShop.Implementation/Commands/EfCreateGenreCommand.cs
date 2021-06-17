using EfDataAccess;
using FluentValidation;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Domain;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands.Genre
{
    public class EfCreateGenreCommand : ICreateGenreCommand
    {
        private readonly MovieContext context;
        private readonly GenreValidator validator;

        public EfCreateGenreCommand(MovieContext context, GenreValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 3;

        public string Name => "Ef create genre";

        public void Execute(GenreDto request)
        {
            validator.ValidateAndThrow(request);

            var genre = new Domain.Genre
            {
                Name = request.Name
            };

            context.Genres.Add(genre);
            context.SaveChanges();
        }
    }
}
