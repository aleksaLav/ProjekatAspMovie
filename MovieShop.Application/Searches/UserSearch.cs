﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
