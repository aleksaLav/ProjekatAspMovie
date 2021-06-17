using EfDataAccess;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Application.Queries;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Queries
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
