using EfDataAccess;
using MovieApp.Application.Commands;
using MovieApp.Application.Exceptions;
using MovieApp.Domain;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace MovieApp.Implementation.Commands
{
    public class EfDeleteDirectorCommand : IDeleteDirectorCommand
    {
        private readonly MovieContext context;
        private readonly DeleteDirectorValidator validator;

        public EfDeleteDirectorCommand(MovieContext context, DeleteDirectorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 14;

        public string Name => "Ef delete director";

        public void Execute(int request)
        {
            validator.ValidateAndThrow(request);
            var director = context.Directors.Find(request);

            if (director == null)
                throw new EntityNotFoundException(request,typeof(Director));

            context.Directors.Remove(director);
            context.SaveChanges();
        }
    }
}
