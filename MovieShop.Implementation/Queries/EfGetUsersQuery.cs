using EfDataAccess;
using MovieApp.Application.Dto;
using MovieApp.Application.Queries;
using MovieApp.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Implementation.Queries
{
    public class EfGetUsersQuery : IGetUserQuery
    {
        private readonly MovieContext context;

        public EfGetUsersQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 22;

        public string Name => "Ef get users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = context.Users
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName) || !string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }


            var skipCount = search.PerPage * (search.Page - 1);

            //Page == 1 
            var reponse = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id, Email = x.Email, Username = x.Username, Password = x.Password

                }).ToList()
            };

            return reponse;
        }
    }
}
