using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Queries
{
    public interface IGetOneActorQuery : IQuery<int, ActorDto>
    {
    }
}
