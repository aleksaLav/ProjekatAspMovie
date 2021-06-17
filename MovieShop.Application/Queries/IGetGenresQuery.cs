using MovieApp.Application.Dto;
using MovieApp.Application.Searches;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Queries
{
    public interface IGetGenresQuery : IQuery<GenreSearch, PagedResponse<GenreDto>>
    {
    }
}
