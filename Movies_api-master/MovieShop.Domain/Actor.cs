﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Domain
{
    public class Actor : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<MovieActor> MovieLinks { get; set; }
    }
}
