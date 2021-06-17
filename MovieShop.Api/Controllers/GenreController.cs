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

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public GenreController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Genre
        [HttpGet]
        public IActionResult Get([FromQuery] GenreSearch search,
            [FromServices] IGetGenresQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
            
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "GetGenre")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Genre
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto dto,
            [FromServices] ICreateGenreCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateGenreDto dto, [FromServices] IUpdateGenreCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);        
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteGenreCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
