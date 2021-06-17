﻿using FluentValidation;
using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MovieShop.Implementation.Validators
{
    public class UpdateDirectorValidator : AbstractValidator<UpdateDirectorDto>
    {
        public UpdateDirectorValidator()
        { 
            RuleFor(a => a.Id).NotEmpty();

            RuleFor(d => d.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(d => d.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
