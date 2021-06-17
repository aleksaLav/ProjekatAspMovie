using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class DeleteMovieValidator : AbstractValidator<int>
    {
        public DeleteMovieValidator()
        {
            RuleFor(m => m).NotEmpty();

        }
    }
}
