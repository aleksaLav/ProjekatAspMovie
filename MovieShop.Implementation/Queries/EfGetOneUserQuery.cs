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
    public class EfGetOneUserQuery : IGetOneUserQuery
    {
        private readonly MovieContext context;

        public EfGetOneUserQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 25;

        public string Name => "Ef get one user";

        public UserDto Execute(int search)
        {
            var user = context.Users.Find(search);

            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };

            return userDto;
        }
    }
}
