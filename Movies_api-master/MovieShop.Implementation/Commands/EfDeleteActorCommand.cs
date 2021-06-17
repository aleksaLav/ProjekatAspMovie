using FluentValidation;
using EfDataAccess;
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
    public class EfDeleteActorCommand : IDeleteActorCommand
    {
        private readonly MovieContext context;
        private readonly DeleteActorValidator validator;

        public EfDeleteActorCommand(MovieContext context, DeleteActorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 11;

        public string Name => "Ef delete actor";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);

            var actor = context.Actors.Find(request);
            if (actor == null)
                throw new EntityNotFoundException(request, typeof(Actor));

            //context.Actors.Remove(actor);
            //context.SaveChanges();
        }
    }
}
