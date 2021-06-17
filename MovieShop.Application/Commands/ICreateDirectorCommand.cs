using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Commands
{
    public interface ICreateDirectorCommand : ICommand<DirectorDto>
    {
    }
}
