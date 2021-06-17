using FluentValidation;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class UpdateGenreValidator : AbstractValidator<GenreDto>
    {
        public UpdateGenreValidator()
        {
            RuleFor(a => a.Id).NotEmpty();

            RuleFor(d => d.Name).NotEmpty().MinimumLength(3);
            
        }
    }
}
