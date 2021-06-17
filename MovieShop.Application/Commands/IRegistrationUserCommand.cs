using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieApp.Application.Commands
{
    public interface IRegistrationUserCommand : ICommand<UserDto>
    {
    }
}
