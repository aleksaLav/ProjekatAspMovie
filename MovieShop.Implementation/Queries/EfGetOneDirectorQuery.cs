using EfDataAccess;
using MovieApp.Application.Dto;
using MovieApp.Application.Exceptions;
using MovieApp.Application.Queries;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Queries
{
    public class EfGetOneDirectorQuery : IGetOneDirectorQuery
    {
        private readonly MovieContext context;

        public EfGetOneDirectorQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 26;

        public string Name => "Ef get one director";

        public DirectorDto Execute(int search)
        {
            var director = context.Directors.Find(search);

            if (director == null)
                throw new EntityNotFoundException(search, typeof(Director));

            var directorDto = new DirectorDto
            {
                 FirstName=director.FirstName,LastName=director.LastName
            };

            return directorDto;
        }
    }
}
