using FluentValidation;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class DeleteActorValidator : AbstractValidator<int>
    {
        public DeleteActorValidator()
        {
            RuleFor(a => a).NotEmpty();

        }
    }
}
