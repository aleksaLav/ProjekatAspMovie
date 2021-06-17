using MovieApp.Application.Dto;
using MovieApp.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Queries
{
    public interface IGetReservationQuery : IQuery<ReservationSearch,PagedResponse<MovieReservationDto>>
    {
    }
}
