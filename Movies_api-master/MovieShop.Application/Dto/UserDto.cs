﻿using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }

    public class UpdateUserDto 
    {
        public int Id { get; set; }
        public IEnumerable<int> UserUseCases { get; set; } = new List<int>();
        public IEnumerable<int> RemoveUserUseCases { get; set; } = new List<int>();

    }
}
