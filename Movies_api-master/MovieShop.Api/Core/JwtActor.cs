using MovieShop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Api.Core
{
    public class JwtActor : IActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> UseCases { get; set; }
    }
}
