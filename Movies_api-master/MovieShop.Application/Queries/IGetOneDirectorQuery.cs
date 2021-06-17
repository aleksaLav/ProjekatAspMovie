using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Queries
{
    public interface IGetOneDirectorQuery : IQuery<int, DirectorDto>
    {
    }
}
