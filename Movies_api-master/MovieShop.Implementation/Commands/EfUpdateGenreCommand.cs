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
    public class EfUpdateGenreCommand : IUpdateGenreCommand
    {
        private readonly MovieContext context;

        public EfUpdateGenreCommand(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 16;

        public string Name => "Ef update genre";

        public void Execute(UpdateGenreDto request)
        {
            var genre = context.Genres.Find(request.Id);
            if (genre == null)
                throw new EntityNotFoundException(request.Id, typeof(Domain.Genre));

            genre.Name = request.Name;

            context.SaveChanges();
        }
    }
}
