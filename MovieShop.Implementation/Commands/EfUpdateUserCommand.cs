using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Exceptions;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Implementation.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly MovieContext context;

        public EfUpdateUserCommand(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 17;

        public string Name => "Ef update user";

        public void Execute(UpdateUserDto request)
        {
            var user = context.Users.Include(u=>u.UserUseCases).Where(x => x.Id == request.Id).First();
            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(User));

            foreach (var idUse in request.RemoveUserUseCases)
            {
                var usecase = context.UserUseCases.Where(u => u.UserId == request.Id && u.UseCaseId == idUse).First();
                context.UserUseCases.Remove(usecase);
            }

            foreach (var idUse in request.UserUseCases)
            {
                context.UserUseCases.Add(new UserUseCase 
                {
                     UserId = request.Id, UseCaseId = idUse   
                });
            }

            context.SaveChanges();
        }
    }
}
