using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class DeleteDirectorValidator : AbstractValidator<int>
    {
        public DeleteDirectorValidator()
        {
            RuleFor(a => a).NotEmpty();
        }
    }
}
