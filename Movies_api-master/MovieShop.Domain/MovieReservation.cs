using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Domain
{
    public class MovieReservation : Entity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public DateTime ReservationDate { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
