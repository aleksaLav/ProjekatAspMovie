using MovieApp.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Api.Core
{
    public class JwtActor : IActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> UseCases { get; set; }
    }
}
