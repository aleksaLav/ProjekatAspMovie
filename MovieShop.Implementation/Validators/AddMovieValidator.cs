using EfDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class AddMovieValidator : AbstractValidator<MovieDto>
    {
        public AddMovieValidator(MovieContext context)
        {
            RuleFor(m => m.Title).NotEmpty().MinimumLength(3);
            RuleFor(m => m.Description).NotEmpty().MinimumLength(25);
            RuleFor(m => m.DirectorId)
                .NotEmpty()
                .Must(director => context.Directors.Any(m => m.Id == director))
                .WithMessage("Director must be valid");

            RuleFor(m => m.ReleaseDate).NotEmpty();
            RuleFor(m => m.OnStock).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(m => m.RuntimeMinutes).NotEmpty().GreaterThan(0);
            
        }
    }
}
