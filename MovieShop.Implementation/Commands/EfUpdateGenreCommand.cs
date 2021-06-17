using EfDataAccess;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Exceptions;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands
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
