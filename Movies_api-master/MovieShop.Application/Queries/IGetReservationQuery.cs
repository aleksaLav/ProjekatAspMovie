using MovieShop.Application.Dto;
using MovieShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Queries
{
    public interface IGetReservationQuery : IQuery<ReservationSearch,PagedResponse<MovieReservationDto>>
    {
    }
}
