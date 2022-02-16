using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SessionDemoApp.Models;
using SessionDemoApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SessionDemoApp.Controller
{
    [Route("[controller]")]
    [ApiController]
    
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
       
        [HttpGet]
        [Route("all")]
        public IActionResult Get()
        {
            return new JsonResult(_movieService.GetAll());

        }


        [HttpPost]
        public IActionResult Post(FormBody movie)
        {
            int index = _movieService.Create(movie);
            return Created($"/movies/{index}", index);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, FormBody movie)
        {
            if (_movieService.Update(id, movie))
                return Ok("Movie Updated Sucessfully.....");
            return Ok("Movie Not Found.....");
        }

    }
}
