using MovieShop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Api.Core
{
    public class AnonimusActor : IActor
    {
        public int Id => 0;

        public string Identity => "Anonimus";

        //public IEnumerable<int> UseCases => new List<int> { 2, 9, 10, 12,13,14,5,15,16 };
        public IEnumerable<int> UseCases => Enumerable.Range(1, 1000);

    }
}
