using FluentValidation;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
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
