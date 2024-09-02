using Microsoft.EntityFrameworkCore;
using Songify.Entities.Entities;
using SongWebApi.Models;

namespace SongWebApi.Services
{
    public class GenreServices
    {
        private readonly SongifyContext _db;
        public GenreServices(SongifyContext songifyContext)
        {
            this._db = songifyContext;
        }

        public List<GenreModel> GetGenre()
        {
            //var aGenre = new GenreModel()
            //{
            //    GenreId = 1,
            //    Name = "Pop"
            //};
            //var genres = new List<GenreModel>();
            //genres.Add(aGenre);

            var genres = _db.Genres.Select(Q => new GenreModel
            {
                GenreId = Q.GenreId,
                Name = Q.Name
            }).ToList();

            return genres;
        }

        public async Task<bool> CreateGenre(GenreModel data)
        {
            var latestGenreId = this._db.Genres.OrderByDescending(Q => Q.GenreId).Select(Q => Q.GenreId).FirstOrDefault();
            var newId = latestGenreId + 1;
            var genre = new Genre
            {
                GenreId = newId,
                Name = data.Name,
            };

            this._db.Genres.Add(genre);

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

        public async Task<bool> DeleteGenre(int id)
        {
            var genre = await this._db.Genres.Where(Q => Q.GenreId == id).FirstOrDefaultAsync();

            if (genre != null)
            {
                this._db.Genres.Remove(genre);
                await this._db.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateGenre(GenreModel data)
        {
            var genre = await this._db.Genres.Where(Q => Q.GenreId == data.GenreId).FirstOrDefaultAsync();

            if (genre != null)
            {
                genre.Name = data.Name;

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
