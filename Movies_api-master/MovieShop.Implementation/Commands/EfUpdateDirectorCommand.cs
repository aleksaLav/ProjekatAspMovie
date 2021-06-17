using EfDataAccess;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Domain;
using MovieShop.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Commands
{
    public class EfUpdateDirectorCommand : IUpdateDirectorCommand
    {
        private readonly MovieContext context;
        private readonly UpdateDirectorValidator validator;

        public EfUpdateDirectorCommand(MovieContext context, UpdateDirectorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 15;

        public string Name => "Ef update director";

        public void Execute(UpdateDirectorDto request)
        {
            validator.ValidateAndThrow(request);

            var director = context.Directors.Find(request.Id);
            if (director == null)
                throw new EntityNotFoundException(request.Id, typeof(Director));

            director.FirstName = request.FirstName;
            director.LastName = request.LastName;

            context.SaveChanges();
        }
    }
}
