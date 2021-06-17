using EfDataAccess;
using MovieShop.Application.Dto;
using MovieShop.Application.Queries;
using MovieShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly MovieContext context;

        public EfGetLogsQuery(MovieContext context)
        {
            this.context = context;
        }

        public int Id => 23;

        public string Name => "Eg get logs";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = context.UseCaseLogs.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (search.DateFrom != DateTime.MinValue)
            {
                query = query.Where(x => x.Date >= search.DateFrom.Date);
            }

            if (search.DateTo != DateTime.MinValue && search.DateTo >= search.DateFrom)
            {
                query = query.Where(x => x.Date <= search.DateTo.Date);
            }


            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<LogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new LogDto
                {
                    Actor = x.Actor, Data = x.Data, Date = x.Date, UseCaseName = x.UseCaseName

                }).ToList()
            };

            return reponse;

        }
    }
}
