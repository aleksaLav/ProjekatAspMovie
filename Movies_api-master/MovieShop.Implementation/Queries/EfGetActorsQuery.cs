using EfDataAccess;
using MovieShop.Application.Dto;
using MovieShop.Application.Queries;
using MovieShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Implementation.Queries
{
    public class EfGetActorsQuery : IGetActorsQuery
    {
        private readonly MovieContext context;

        public EfGetActorsQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 12;

        public string Name => "Ef get actors";

        public PagedResponse<ActorDto> Execute(ActorSearch search)
        {
            var query = context.Actors
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

            var reponse = new PagedResponse<ActorDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new ActorDto
                {
                    FirstName=x.FirstName,
                    LastName=x.LastName

                }).ToList()
            };

            return reponse;
        }
    }
}
