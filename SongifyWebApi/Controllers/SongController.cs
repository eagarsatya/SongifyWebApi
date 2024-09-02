using Microsoft.AspNetCore.Mvc;
using SongifyWebApi.Models;
using SongifyWebApi.Services;

namespace SongifyWebApi.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongService _services;

        public SongController(SongService songService)
        {
            _services = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = _services.GetSongs();
            return Ok(songs);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSong([FromBody] SongModel song)
        {
            if (!ModelState.IsValid)
            {
                // Log model state errors
                foreach (var state in ModelState)
                {
                    Console.WriteLine($"{state.Key}: {state.Value.Errors.FirstOrDefault()?.ErrorMessage}");
                }
                return BadRequest(ModelState);
            }

            var isSuccess = await _services.CreateSong(song);

            if (isSuccess)
            {
                return Ok(song);
            }
            else
            {
                return BadRequest("Could not create the song.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var isSuccess = await _services.DeleteSong(id);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Song Not Found");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromBody] SongModel data)
        {
            var isSuccess = await _services.UpdateSong(data);

            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Song Not Found");
            }
        }
    }
}
