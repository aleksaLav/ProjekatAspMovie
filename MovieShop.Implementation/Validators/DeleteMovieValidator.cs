using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class DeleteMovieValidator : AbstractValidator<int>
    {
        public DeleteMovieValidator()
        {
            RuleFor(m => m).NotEmpty();

        }
    }
}
