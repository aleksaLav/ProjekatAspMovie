using MovieApp.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands
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
