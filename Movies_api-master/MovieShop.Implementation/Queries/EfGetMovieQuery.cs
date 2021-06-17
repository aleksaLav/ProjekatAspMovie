using AutoMapper;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using MovieShop.Application.Dto;
using MovieShop.Application.Queries;
using MovieShop.Application.Searches;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MovieShop.Implementation.Queries
{
    public class EfGetMovieQuery : IGetMovieQuery
    {
        private readonly MovieContext context;
        private readonly IMapper mapper;

        public EfGetMovieQuery(MovieContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Movie Search";

        public PagedResponse<MovieDtoShow> Execute(MovieSearch search)
        {
            var query = context.Movies
    
                .Include(m => m.GenresLinks)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var skiped = query.Skip(skipCount).Take(search.PerPage);

            //Page == 1 
            var reponse = new PagedResponse<MovieDtoShow>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                //Items = mapper.Map<IEnumerable<MovieDtoShow>>(skiped)

                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new MovieDtoShow
                {
                    Title = x.Title,
                    OnStock = x.OnStock,
                    Description = x.Description,
                    ReleaseDate = x.ReleaseDate,
                    RuntimeMinutes = x.RuntimeMinutes,
                    Actors = x.ActorsLinks.Select(x => new ActorDto 
                    {
                         Id = x.Actor.Id, FirstName=x.Actor.FirstName, LastName=x.Actor.LastName
                    }).ToList(),
                    Director = new UpdateDirectorDto { Id = x.Director.Id, FirstName = x.Director.FirstName, LastName = x.Director.LastName },
                      Genres = x.GenresLinks.Select(x => new GenreDto { 
                          Id = x.Genre.Id, Name = x.Genre.Name 
                      }).ToList()
                      
                    }).ToList()
                };

            return reponse;
        }
    }
}
