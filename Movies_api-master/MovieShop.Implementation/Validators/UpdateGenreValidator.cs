using FluentValidation;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
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
