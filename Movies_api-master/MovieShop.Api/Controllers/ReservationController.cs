using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Application;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Application.Queries;
using MovieShop.Application.Searches;

namespace MovieShop.Api.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IActor actor;
        private readonly UseCaseExecutor executor;

        public ReservationController(IActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Reservation
        [HttpGet]
        public IActionResult Get([FromServices] IGetReservationQuery query, ReservationSearch search)
        {
            
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Reservation/5
        [HttpGet("{id}", Name = "GetReservation")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        [HttpPost]
        public IActionResult Post([FromBody] MovieReservationDto dto, [FromServices] ICreateMovieReservationCommand command)
        {
            dto.UserId = actor.Id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
