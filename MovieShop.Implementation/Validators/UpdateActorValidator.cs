using FluentValidation;
using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Validators
{
    public class UpdateActorValidator : AbstractValidator<ActorDto>
    {
        public UpdateActorValidator()
        {
            RuleFor(a => a.Id).NotEmpty();

            RuleFor(a => a.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(a => a.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
