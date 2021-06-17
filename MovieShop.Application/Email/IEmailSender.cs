using MovieApp.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
