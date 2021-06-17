using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Queries;
using MovieApp.Application.Searches;
using MovieApp.Domain;
using MovieApp.Implementation.Queries;

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActorsController : ControllerBase
    {
        private readonly MovieContext context;
        private readonly UseCaseExecutor executor;

        public ActorsController(MovieContext context, UseCaseExecutor executor)
        {
            this.context = context;
            this.executor = executor;
        }

        // GET: api/Actors
        [HttpGet]
        public IActionResult Get([FromQuery] ActorSearch search, [FromServices] IGetActorsQuery query)
        {
            //var actors = context.Actors.ToList();
            return Ok(executor.ExecuteQuery(query, search));
                
        }

        // GET: api/Actors/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, [FromServices] IGetOneActorQuery query)
        {
            var actor = executor.ExecuteQuery(query, id);
            return Ok(actor);
        }

        // POST: api/Actors
        [HttpPost]
        public IActionResult Post([FromBody] ActorDto dto,
            [FromServices] ICreateActorCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);

        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorDto dto, [FromServices] IUpdateActorCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteActorCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
