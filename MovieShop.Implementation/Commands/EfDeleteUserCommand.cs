using EfDataAccess;
using MovieApp.Application.Commands;
using MovieApp.Application.Exceptions;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly MovieContext context;

        public EfDeleteUserCommand(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 29;

        public string Name => "Ef soft delete user";

        public void Execute(int request)
        {
            var user = context.Users.Find(request);

            if (user == null)
                throw new EntityNotFoundException(request, typeof(User));

            user.IsDeleted = true;
            user.SoftDeleted = DateTime.Now;

            context.SaveChanges();
        }
    }
}
