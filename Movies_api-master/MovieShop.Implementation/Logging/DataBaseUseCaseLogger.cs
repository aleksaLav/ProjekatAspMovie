using EfDataAccess;
using MovieShop.Application;
using MovieShop.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Implementation.Logging
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

