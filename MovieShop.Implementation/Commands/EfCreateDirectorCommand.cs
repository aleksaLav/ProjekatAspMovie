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
    public class EfCreateDirectorCommand : ICreateDirectorCommand
    {
        private readonly MovieContext context;
        private readonly DirectorValidator validator;

        public EfCreateDirectorCommand(MovieContext context, DirectorValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 5;

        public string Name => "Ef create director";

        public void Execute(DirectorDto request)
        {
            //validacija
            validator.ValidateAndThrow(request);

            var director = new Director
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            context.Directors.Add(director);
            context.SaveChanges();
        }
    }
}
