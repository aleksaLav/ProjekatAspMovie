using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Domain
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> MovieLinks { get; set; }
    }
}
