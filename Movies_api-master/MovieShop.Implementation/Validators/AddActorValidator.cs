using FluentValidation;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class AddActorValidator : AbstractValidator<ActorDto>
    {
        public AddActorValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(a => a.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
