using EfDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class RegistationValidator : AbstractValidator<UserDto>
    {
        public RegistationValidator(MovieContext context)
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(3);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
            RuleFor(u => u.Username)
                .Must(username => !context.Users.Any(u => u.Username == username))
                .WithMessage("Username je zauzet");

        }
    }
}
