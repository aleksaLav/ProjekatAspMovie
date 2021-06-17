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
    public class EfGetGenresQuery : IGetGenresQuery
    {
        private readonly MovieContext context;

        public EfGetGenresQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 19;

        public string Name => "Ef get genres";

        public PagedResponse<GenreDto> Execute(GenreSearch search)
        {
            var query = context.Genres
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }


            var skipCount = search.PerPage * (search.Page - 1);

            //Page == 1 
            var reponse = new PagedResponse<GenreDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new GenreDto
                {
                    Name = x.Name,
                     Id=x.Id
                }).ToList()
            };

            return reponse;
        }

    }
}
