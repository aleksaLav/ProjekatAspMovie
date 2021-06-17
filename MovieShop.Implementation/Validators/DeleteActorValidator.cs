using FluentValidation;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class DeleteActorValidator : AbstractValidator<int>
    {
        public DeleteActorValidator()
        {
            RuleFor(a => a).NotEmpty();

        }
    }
}
