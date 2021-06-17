using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Domain
{
    public class Director : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
