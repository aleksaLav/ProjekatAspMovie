using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Dto
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
