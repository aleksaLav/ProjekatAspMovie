using MovieShop.Application.Dto;
using MovieShop.Application.Searches;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Queries
{
    public interface IGetGenresQuery : IQuery<GenreSearch, PagedResponse<GenreDto>>
    {
    }
}
