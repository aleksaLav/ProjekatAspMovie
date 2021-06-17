using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Application;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;

namespace MovieShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UseCaseExecutor executor;

        public RegistrationController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        // GET: api/Registration
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto,
            [FromServices] IRegistrationUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return Ok();
        }

    }
}
