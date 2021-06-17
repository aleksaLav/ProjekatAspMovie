using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using MovieShop.Application.Dto;
using MovieShop.Application.Queries;
using MovieShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Implementation.Queries
{
    public class EfGetReservationsQuery : IGetReservationQuery
    {
        private readonly MovieContext context;

        public EfGetReservationsQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 24;

        public string Name => "Ef get reservations";

        public PagedResponse<MovieReservationDto> Execute(ReservationSearch search)
        {
            var query = context.MovieReservations.Include(r => r.Movie).Include(r => r.User)
               .AsQueryable();


            var skipCount = search.PerPage * (search.Page - 1);

            //Page == 1 
            var reponse = new PagedResponse<MovieReservationDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new MovieReservationDto
                {
                   MovieId = x.MovieId, 
                   UserId=x.UserId
                   , Movie = new MovieDto 
                   { 
                       Title=x.Movie.Title,
                        Description=x.Movie.Description,
                        OnStock = x.Movie.OnStock,
                        ReleaseDate = x.Movie.ReleaseDate,
                        RuntimeMinutes = x.Movie.RuntimeMinutes,
                        DirectorId = x.Movie.DirectorId
                   }
                }).ToList()
            };

            return reponse;
        }
    }
}
