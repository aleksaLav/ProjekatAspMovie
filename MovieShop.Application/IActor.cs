using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application
{
    public interface IActor
    {
        public int Id { get; }

        public string Identity { get; }

        public IEnumerable<int> UseCases { get;}
    }
}
