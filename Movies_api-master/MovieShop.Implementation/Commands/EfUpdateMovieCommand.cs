using EfDataAccess;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Commands
{
    public class EfUpdateMovieCommand : IUpdateMovieCommand
    {
        private readonly MovieContext context;

        public EfUpdateMovieCommand(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 27;

        public string Name => "Ef update movie";

        public void Execute(UpdateMovieDto request)
        {
            var movie = context.Movies.Find(request.Id);
            if (movie == null)
                throw new EntityNotFoundException(request.Id, typeof(Movie));

            if(request.Title != null)
            {
                movie.Title = request.Title;
            }
            if (request.Description != null)
            {
                movie.Description = request.Description;
            }
            
            movie.OnStock = request.OnStock;
            movie.ReleaseDate = request.ReleaseDate;
            movie.RuntimeMinutes = request.RuntimeMinutes;

            context.SaveChanges();
        }
    }
}
