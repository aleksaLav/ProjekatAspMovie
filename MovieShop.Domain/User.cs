using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
        public virtual ICollection<MovieReservation> MovieReservations { get; set; }


    }
}
