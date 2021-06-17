using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Queries
{
    public interface IGetOneActorQuery : IQuery<int, ActorDto>
    {
    }
}
