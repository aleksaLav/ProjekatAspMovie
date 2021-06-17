using MovieApp.Application.Dto;
using MovieApp.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Queries
{
    public interface IGetMovieQuery : IQuery<MovieSearch, PagedResponse<MovieDtoShow>>
    {

    }
}
