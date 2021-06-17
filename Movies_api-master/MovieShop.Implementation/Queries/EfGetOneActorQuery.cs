using EfDataAccess;
using MovieShop.Application.Dto;
using MovieShop.Application.Exceptions;
using MovieShop.Application.Queries;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Queries
{
    public class EfGetOneActorQuery : IGetOneActorQuery
    {
        private readonly MovieContext context;

        public EfGetOneActorQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 10;

        public string Name => "Ef get one actor";

        public ActorDto Execute(int search)
        {
            var actor = context.Actors.Find(search);

            if(actor == null)
            {
               throw new EntityNotFoundException(search,typeof(Actor));
            }

            var actordto = new ActorDto
            {
                Id = actor.Id,
                FirstName = actor.FirstName,
                LastName = actor.LastName
            };

            return actordto;
        }
    }
}
