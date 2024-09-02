using SongifyEntities.Entities;
using SongifyWebApi.Models;

namespace SongifyWebApi.Services
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
                Name = Q.Name,
            }).ToList();

            return genres;
        }
        public async Task<bool> CreateGenre(GenreModel data)
        {
            var latestGenreId = this._db.Genres.OrderByDescending(Q => Q.GenreId).Select(Q => Q.GenreId).FirstOrDefault();
            var genre = new Genre
            {
                GenreId = data.GenreId,
                Name = data.Name
            };

            this._db.Genres.Add(genre);

            await this._db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            var genre = this._db.Genres.Where(Q => Q.GenreId == id).FirstOrDefault();

            if (genre != null)
            {
                this._db.Genres.Remove(genre);
                this._db.Remove(genre);
                await this._db.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }
        public async Task<bool> UpdateGenre(GenreModel data)
        {
            var genre = this._db.Genres.Where(Q => Q.GenreId == data.GenreId).FirstOrDefault();

            if (genre != null)
            {
                genre.Name = data.Name;
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
