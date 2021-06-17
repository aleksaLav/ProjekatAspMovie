using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int OnStock { get; set; }

        public int RuntimeMinutes { get; set; }
        public int DirectorId { get; set; }
        
        public virtual Director Director { get; set; }
        public virtual ICollection<MovieGenre> GenresLinks { get; set; } = new List<MovieGenre>();
        public virtual ICollection<MovieActor> ActorsLinks { get; set; } = new List<MovieActor>();

        public virtual ICollection<MovieReservation> MovieReservations { get; set; } = new List<MovieReservation>();
    }
}
