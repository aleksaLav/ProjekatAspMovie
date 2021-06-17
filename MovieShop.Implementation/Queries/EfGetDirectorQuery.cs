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
    public class EfGetDirectorQuery : IGetDirectorQuery
    {
        private readonly MovieContext context;

        public EfGetDirectorQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 13;

        public string Name => "Ef get directors";

        public PagedResponse<DirectorDto> Execute(DirectorSearch search)
        {
            var query = context.Directors
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
            var reponse = new PagedResponse<DirectorDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new DirectorDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName

                }).ToList()
            };

            return reponse;
        }
    }
}
