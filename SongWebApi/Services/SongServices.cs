using Microsoft.EntityFrameworkCore;
using Songify.Entities.Entities;
using SongWebApi.Models;

namespace SongWebApi.Services
{
    public class SongServices
    {
        private readonly SongifyContext _db;
        public SongServices(SongifyContext songifyContext)
        {
            this._db = songifyContext;
        }

        public List<SongModel> GetSong()
        {
            var songs = _db.Songs.Select(Q => new SongModel
            {
                SongId = Q.SongId,
                Title = Q.Title,
                ReleasedDate = Q.ReleasedDate,
                GenreId = Q.GenreId
            }).ToList();

            return songs;
        }

        //public List<SongWithGenreModel> GetSongsWithGenres()
        //{
        //    var songsWithGenres = from song in _db.Songs
        //                          join genre in _db.Genres on song.GenreId equals genre.GenreId
        //                          select new SongWithGenreModel
        //                          {
        //                              SongId = song.SongId,
        //                              Title = song.Title,
        //                              ReleasedDate = song.ReleasedDate,
        //                              GenreName = genre.Name
        //                          };

        //    return [.. songsWithGenres];
        //}


        public async Task<bool> CreateSong(SongModel data)
        {
            var song = new Song
            {
                Title = data.Title,
                ReleasedDate = data.ReleasedDate,
                GenreId = data.GenreId
            };

            this._db.Songs.Add(song);

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return true;
        }

        public async Task<bool> DeleteSong(int id)
        {
            var song = await this._db.Songs.Where(Q => Q.SongId == id).FirstOrDefaultAsync();

            if (song != null)
            {
                this._db.Songs.Remove(song);
                await this._db.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateSong(SongModel data)
        {
            var song = await this._db.Songs.Where(Q => Q.SongId == data.SongId).FirstOrDefaultAsync();

            if (song != null)
            {
                song.Title = data.Title;

                await this._db.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
