using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class DeleteGenreValidator : AbstractValidator<int>
    {
        public DeleteGenreValidator()
        {
            RuleFor(a => a).NotEmpty();
        }
    }
}
