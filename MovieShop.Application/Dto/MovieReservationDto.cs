using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Dto
{
    public class MovieReservationDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public DateTime ReservationDate { get; set; }

        public MovieDto Movie { get; set; }
    }
}
