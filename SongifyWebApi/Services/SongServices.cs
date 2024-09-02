using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Songify.Entities.Entities;
using SongifyWebApi.Models;

namespace SongifyWebApi.Services
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
            //var aGenre = new GenreModel()
            //{
            //    GenreId = 1,
            //    Name = "Pop"
            //};
            //var genres = new List<GenreModel>();
            //genres.Add(aGenre);

            var songs = _db.Songs.Select(Q => new SongModel
            {
                SongId = Q.SongId,
                Title = Q.Title,
                ReleasedDate = Q.ReleasedDate,
                GenreId = Q.GenreId,
                CreatedAt = Q.CreatedAt,
                CreatedBy = Q.CreatedBy,
                UpdatedAt = Q.UpdatedAt,
                UpdatedBy = Q.UpdatedBy,
            }).ToList();

            return songs;
        }

        public async Task<bool> CreateSong(SongModel data)
        {
            //var latestSongId = this._db.Songs.OrderByDescending(Q => Q.SongId).Select(Q => Q.SongId).FirstOrDefault();
            //var newId = latestSongId + 1;
            var song = new Song
            {
                //SongId = data.SongId,
                Title = data.Title,
                ReleasedDate = data.ReleasedDate,
                GenreId = data.GenreId,
                CreatedAt = data.CreatedAt,
                CreatedBy = data.CreatedBy,
                UpdatedAt = data.UpdatedAt,
                UpdatedBy = data.UpdatedBy,
            };

            this._db.Songs.Add(song);

            await this._db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSong(int id)
        {
            var song = await this._db.Songs.Where(Q =>  Q.SongId == id).FirstOrDefaultAsync();

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
                song.ReleasedDate = data.ReleasedDate;
                song.GenreId = data.GenreId;
                song.CreatedAt = data.CreatedAt;
                song.CreatedBy = data.CreatedBy;
                song.UpdatedAt = data.UpdatedAt;
                song.UpdatedBy = data.UpdatedBy;

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
