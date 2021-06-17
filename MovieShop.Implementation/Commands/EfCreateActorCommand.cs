using EfDataAccess;
using FluentValidation;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Domain;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands
{
    public class EfCreateActorCommand : ICreateActorCommand
    {
        private readonly MovieContext context;
        private readonly AddActorValidator validator;

        public EfCreateActorCommand(MovieContext context, AddActorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 1;

        public string Name => "Ef create actor";

        public void Execute(ActorDto request)
        {
            validator.ValidateAndThrow(request);

            //ubacivanje u bazu
            var actor = new Actor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            context.Actors.Add(actor);

            context.SaveChanges();
        }
    }
}
