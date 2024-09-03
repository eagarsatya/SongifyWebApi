using Microsoft.AspNetCore.Mvc;
using SongWebApi.Services;

namespace SongWebApi.Controllers
{
    [Route("api/song-with-genre")]
    [ApiController]
    public class SongWithGenreController : ControllerBase
    {
        private readonly SongWithGenreServices _services;

        public SongWithGenreController(SongWithGenreServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongWithGenre()
        {
            var song = _services.GetSongsWithGenres();
            return Ok(song);
        }
    }
}
