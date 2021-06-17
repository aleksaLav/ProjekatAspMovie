using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseController : ControllerBase
    {
        // GET: api/UseCase
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UseCase/5
        [HttpGet("{id}", Name = "GetUseCase")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UseCase
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UseCase/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //add usecase to user

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
