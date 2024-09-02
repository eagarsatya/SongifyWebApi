using Microsoft.AspNetCore.Mvc;
using SongWebApi.Models;
using SongWebApi.Services;

namespace SongWebApi.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongServices _services;

        public SongController(SongServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetSong()
        {
            var song = _services.GetSong();
            return Ok(song);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSong([FromBody] SongModel data)
        {
            var isSuccess = await _services.CreateSong(data);

            if (isSuccess)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Unable to create song.");
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
                return BadRequest("Song not found.");
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
                return BadRequest("Song not found.");
            }
        }
    }
}
