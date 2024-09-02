using Songify.Entities.Entities;
using SongifyWebApi.Models;

namespace SongifyWebApi.Services
{
    public class SongServices
    {
        public SongServices(SongifyContext songifyContext)
        {
            this._db = songifyContext;
        }

        public List<SongModel> GetSong()
        {
            var genres = _db.Genres.Select(Q => new SongModel
            {
                SongId = Q.SongId,
                Title = Q.Title,
                ReleasedDate = Q.ReleasedDate, 
                GenreId = Q.GenreId
            }).ToList();
            return songs;
        }

        public async Task<bool> CreateSong(SongModel data)
        {
            var song = new Song
            {
                Title = data.Title,
                ReleasedDate = data.ReleasedDate,
                GenreId = data.GenreId
            };
            this._db.Songs.Add(song);
            await this._db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSong(int id)
        {
            var song = this._db.Songs.Where(Q => Q.SongId == id).FirstOrDefault();
            if (song != null)
            {
                this._db.Songs.Remove(song);
                await this._db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateSong(SongModel data)
        {
            var song = this._db.Songs.Where(Q => Q.SongId == data.SongId).FirstOrDefault();
            if (song != null)
            {
                song.Title = data.Title;
                song.UpdatedAt = DateTimeOffset.UtcNow;
                await this._db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
