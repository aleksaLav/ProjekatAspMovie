using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfDataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Domain;

namespace MovieShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TestController : ControllerBase
    {
        private readonly MovieContext context;

        public TestController(MovieContext context)
        {
            this.context = context;
        }

        // GET: api/Test
        [HttpGet]
        public IActionResult Get()
        {
            var genre = new Genre
            {
                Name = "Genre2"
            };

            //var genreTest = context.Genres.Find(1);

            //context.Genres.Add(genre);

            //var director = new Director
            //{
            //    FirstName = "Pera", LastName = "Peric"
            //};

            //context.Director.Add(director);
            //var movie = new Movie
            //{
            //    Title = "Title1",
            //    Description = "description",
            //    ReleaseDate = DateTime.Now,
            //    Count = 2,
            //    RuntimeMinutes = 60,
            //    DirectorId = 1
            //};

            //movie.MovieGenres = new List<MovieGenre>
            //    {
            //        new MovieGenre {
            //        Movie = movie,
            //        Genre=genre
            //        }
            //    };


            //context.Movies.Add(movie);
            //context.SaveChanges();
            return Ok();
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "GetTest")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
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
