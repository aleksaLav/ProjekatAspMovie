using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class DeleteDirectorValidator : AbstractValidator<int>
    {
        public DeleteDirectorValidator()
        {
            RuleFor(a => a).NotEmpty();
        }
    }
}
