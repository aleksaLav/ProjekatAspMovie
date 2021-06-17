using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MovieShop.Application.Commands
{
    public interface IRegistrationUserCommand : ICommand<UserDto>
    {
    }
}
