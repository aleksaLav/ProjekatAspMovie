using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
