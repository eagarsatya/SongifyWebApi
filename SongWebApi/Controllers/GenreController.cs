using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongWebApi.Models;
using SongWebApi.Services;
using SongWebApi.Models;
using System.Xml.Linq;

namespace SongWebApi.Controllers
{
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
                return Ok();
            }
            else
            {
                return BadRequest("Genre Not Found");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreModel data)
        {
            var isSuccess = await _services.UpdateGenre(data);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Genre Not Found");
            }
        }
    }
}

