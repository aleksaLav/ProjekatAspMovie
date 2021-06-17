using EfDataAccess;
using FluentValidation;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Email;
using MovieApp.Domain;
using MovieApp.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands
{
    public class EfRegistrationUserCommand : IRegistrationUserCommand
    {
        private readonly MovieContext context;
        private readonly RegistationValidator validator;
        private readonly IEmailSender sender;
        private IEnumerable<int> useCasesForUser = new List<int> { 2, 9, 20, 7 };


        public EfRegistrationUserCommand(MovieContext context, RegistationValidator validator, IEmailSender sender)
        {
            this.context = context;
            this.validator = validator;
            this.sender = sender;
        }

        public int Id => 2;

        public string Name => "Ef - user registration";

        public void Execute(UserDto request)
        {
            //validacija podataka za korisnika
            validator.ValidateAndThrow(request);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password),
                //Password =  request.Password,
                Email = request.Email
            };

            context.Users.Add(user);
            context.SaveChanges();

            int id = user.Id;

            foreach (var c in useCasesForUser)
            {
                context.UserUseCases.Add(new UserUseCase
                {
                    UserId = id,
                    UseCaseId = c
                });
            }


            context.SaveChanges();

            sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration on MovieShop. Welcome</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
