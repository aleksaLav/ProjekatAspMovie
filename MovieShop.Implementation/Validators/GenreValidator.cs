using EfDataAccess;
using FluentValidation;
using MovieApp.Application.Dto;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class GenreValidator : AbstractValidator<GenreDto>
    {
        public GenreValidator(MovieContext context)
        {
            RuleFor(g => g.Name).NotEmpty().MinimumLength(4);
            RuleFor(g => g.Name)
                .Must(name => !context.Genres.Any(g => g.Name == name))
                .WithMessage("Genre olready exist");

        }
    }
}
