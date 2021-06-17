using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminUserController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public AdminUserController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/AdminUser
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/AdminUser/5
        [HttpGet("{id}", Name = "GetAdminUsers")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/AdminUser
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/AdminUser/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            //soft delete
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
