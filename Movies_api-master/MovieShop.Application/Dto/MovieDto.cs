using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Dto
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int OnStock { get; set; }
        public int RuntimeMinutes { get; set; }

        public int DirectorId { get; set; }
        public virtual ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public virtual ICollection<ActorDto> Actors { get; set; } = new List<ActorDto>();
    }


    public class MovieDtoShow
        {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int OnStock { get; set; }
        public int RuntimeMinutes { get; set; }

        public UpdateDirectorDto Director { get; set; }
        public virtual ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public virtual ICollection<ActorDto> Actors { get; set; } = new List<ActorDto>();
    }

    public class MovieGenreDto 
    {
        public int GenreId { get; set; }
    }

    public class MovieActorDto
    {
        public int ActorId { get; set; }
    }

    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int OnStock { get; set; }
        public int RuntimeMinutes { get; set; }

    }
}
