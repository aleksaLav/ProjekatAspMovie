using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Dto
{
    public class DirectorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class UpdateDirectorDto {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
