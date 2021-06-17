using MovieShop.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Commands
{
    public class EfGetOneGenreCommand : IGetOneGenreCommand
    {
        public int Id => 28;

        public string Name => "Ef get one genre";

        public void Execute(int request)
        {
            
        }
    }
}
