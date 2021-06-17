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
    public class AddReservationValidator : AbstractValidator<MovieReservationDto>
    {
        public AddReservationValidator(MovieContext context)
        {
            RuleFor(r => r.MovieId)
                .NotEmpty()
                .Must(movie => context.Movies.Any(r => r.Id == movie)).WithMessage("Movie not exist");

            RuleFor(r => r.UserId)
            .NotEmpty()
            .Must(user => context.Users.Any(r => r.Id == user)).WithMessage("User not exist");

          
        }

    }
}
