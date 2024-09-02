using Microsoft.EntityFrameworkCore;
using Songify.Entities.Entities;
using SongifyWebApi.Models;

namespace SongifyWebApi.Services
{
    public class SongService
    {
        private readonly SongifyContext _db;

        public SongService(SongifyContext songifyContext)
        {
            _db = songifyContext;
        }

        public List<SongModel> GetSongs()
        {
            return _db.Songs.Include(s => s.Genre).Select(Q => new SongModel
            {
                SongId = Q.SongId,
                Title = Q.Title,
                ReleasedDate = Q.ReleasedDate,
                GenreId = Q.GenreId,
                CreatedAt = Q.CreatedAt,
                CreatedBy = Q.CreatedBy,
                UpdatedAt = Q.UpdatedAt,
                UpdatedBy = Q.UpdatedBy
            }).ToList();
        }

        public async Task<bool> CreateSong(SongModel data)
        {
            var song = new Song
            {
                Title = data.Title,
                ReleasedDate = data.ReleasedDate,
                GenreId = data.GenreId,
                CreatedAt = DateTimeOffset.Now,
                CreatedBy = data.CreatedBy,
                UpdatedAt = DateTimeOffset.Now,
                UpdatedBy = data.UpdatedBy
            };

            _db.Songs.Add(song);

            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating song: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSong(int id)
        {
            var song = await _db.Songs.Where(Q => Q.SongId == id).FirstOrDefaultAsync();

            if (song != null)
            {
                _db.Songs.Remove(song);
                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting song: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateSong(SongModel data)
        {
            var song = await _db.Songs.Where(Q => Q.SongId == data.SongId).FirstOrDefaultAsync();

            if (song != null)
            {
                song.Title = data.Title;
                song.ReleasedDate = data.ReleasedDate;
                song.GenreId = data.GenreId;
                song.UpdatedAt = DateTimeOffset.Now;
                song.UpdatedBy = data.UpdatedBy;

                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating song: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
