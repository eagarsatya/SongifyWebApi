using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongifyWebApi.Models;
using SongifyWebApi.Services;

namespace SongifyWebApi.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongServices _services;

        public SongController(SongServices songServices)
        {
            _services = songServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetSong()
        {
            var song = this._services.GetSong();

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
                return BadRequest();
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
            var isSuccess = await this._services.UpdateSong(data);

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
