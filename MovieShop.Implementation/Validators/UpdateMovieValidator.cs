using FluentValidation;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieValidator()
        {
            RuleFor(m => m.Title).NotEmpty().MinimumLength(3);
            RuleFor(m => m.Description).NotEmpty().MinimumLength(25);
            RuleFor(m => m.ReleaseDate).NotEmpty();
            RuleFor(m => m.OnStock).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(m => m.RuntimeMinutes).NotEmpty().GreaterThan(0);
        }
    }
}
