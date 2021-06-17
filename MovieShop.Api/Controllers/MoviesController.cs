using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
using EfDataAccess.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application;
using MovieApp.Application.Commands;
using MovieApp.Application.Dto;
using MovieApp.Application.Queries;
using MovieApp.Application.Searches;
using MovieApp.Domain;

namespace MovieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public MoviesController(UseCaseExecutor executor, MovieContext context)
        {
            this.executor = executor;
        }


        // GET: api/Movies
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search, [FromServices] IGetMovieQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovies")]
        public IActionResult Get(int id, [FromServices] IGetOneMovieQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Movies
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MovieDto dto, [FromServices] ICreateMovieCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        [Authorize]

        public void Put(int id, [FromServices] IUpdateMovieCommand command,UpdateMovieDto dto )
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id, [FromServices] IDeleteMovieCommand command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
