﻿using EfDataAccess;
using FluentValidation;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Domain;
using MovieShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Commands
{
    public class EfUpdateActorCommand : IUpdateActorCommand
    {
        private readonly MovieContext context;
        private readonly UpdateActorValidator validator;

        public EfUpdateActorCommand(MovieContext context, UpdateActorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 18;

        public string Name => "Ef update actor";

        public void Execute(ActorDto request)
        {
            validator.ValidateAndThrow(request);

            var actor = context.Directors.Find(request);

            if(actor==null)
                throw new EntityNotFoundException(request.Id, typeof(Actor));

            actor.FirstName = request.FirstName;
            actor.LastName = request.LastName;

            context.SaveChanges();
        }
    }
}
