using FluentValidation;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class DirectorValidator : AbstractValidator<DirectorDto>
    {
        public DirectorValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(d => d.LastName).NotEmpty().MinimumLength(3);

        }
    }
}
