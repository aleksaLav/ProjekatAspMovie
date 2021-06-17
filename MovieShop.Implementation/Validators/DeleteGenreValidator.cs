using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class DeleteGenreValidator : AbstractValidator<int>
    {
        public DeleteGenreValidator()
        {
            RuleFor(a => a).NotEmpty();
        }
    }
}
