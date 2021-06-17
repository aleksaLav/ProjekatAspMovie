using MovieShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
