using Microsoft.AspNetCore.Mvc;
using SongifyWebApi.Models;
using SongifyWebApi.Services;

namespace SongifyWebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreServices _services;
        public GenreController(GenreServices genreServices)
        {
            _services = genreServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenre()
        {
            var genre = this._services.GetGenre();

            return Ok(genre);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateGenre([FromBody] GenreModel data)
        {
            var isSuccess = await _services.CreateGenre(data);
            if (isSuccess)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var isSuccess = await _services.DeleteGenre(id);
            if (isSuccess)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreModel data)
        //{
        //    var isSuccess = await _services.DeleteGenre(id, data);
        //    if (isSuccess)
        //    {
        //        return Ok(id);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreModel data)
        {
            var isSuccess = await _services.UpdateGenre(data);
            if (isSuccess)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
