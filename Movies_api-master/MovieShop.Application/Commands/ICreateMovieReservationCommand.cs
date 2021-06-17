using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Commands
{
    public interface ICreateMovieReservationCommand : ICommand<MovieReservationDto>
    {
    }
}
