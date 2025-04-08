using Ingresso.Application.DTOs.MovieDTOs;
using Ingresso.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ingresso.Api.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) => _movieService = movieService;

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetBySlugAsync([FromQuery] string slug)
        {
            var result = await _movieService.GetBySlugAsync(slug);  
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        
        [HttpGet]
        [Route("get-with-description")]
        public async Task<ActionResult> GetBySlugWithDescriptionAsync([FromQuery] string slug)
        {
            var result = await _movieService.GetBySlugWithDescriptionAsync(slug);  
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync([FromForm] string movie, [FromForm] IFormFile PosterImage, [FromForm] IFormFile BannerImage)
        {
            MovieDTO movieDTO = JsonConvert.DeserializeObject<MovieDTO>(movie);
            var result = await _movieService.CreateAsync(movieDTO, PosterImage, BannerImage);  
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] int movieId)
        {
            var result = await _movieService.DeleteAsync(movieId);  
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
