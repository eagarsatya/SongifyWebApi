using Songify.Entities.Entities;
using SongWebApi.Models;

namespace SongWebApi.Services
{
    public class SongWithGenreServices
    {
        private readonly SongifyContext _db;
        public SongWithGenreServices(SongifyContext songifyContext)
        {
            this._db = songifyContext;
        }

        public List<SongWithGenreModel> GetSongsWithGenres()
        {
            var songsWithGenres = from song in _db.Songs
                                  join genre in _db.Genres on song.GenreId equals genre.GenreId
                                  select new SongWithGenreModel
                                  {
                                      SongId = song.SongId,
                                      Title = song.Title,
                                      ReleasedDate = song.ReleasedDate,
                                      GenreName = genre.Name
                                  };

            return [.. songsWithGenres];
        }
    }
}
