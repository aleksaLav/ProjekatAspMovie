using MovieShop.Application.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Application
{
    public class UseCaseExecutor
    {
        private readonly IActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            Console.WriteLine($"{DateTime.Now}, {command.Name} using data: " +
                $"{JsonConvert.SerializeObject(request)}");

            logger.Log(command, actor, request);

            if (!actor.UseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor, search);

            if (!actor.UseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, actor);
            }

            return query.Execute(search);
        }
    }
}
