using EfDataAccess;
using MovieApp.Application;
using MovieApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Implementation.Logging
{
    public class DataBaseUseCaseLogger : IUseCaseLogger
    {


        private readonly MovieContext context;

        public DataBaseUseCaseLogger(MovieContext context)
        {
            this.context = context;
        }

        public void Log(IUseCase useCase, IActor actor, object useCaseData)
        {
            context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });

            context.SaveChanges();
        }
    }
}

