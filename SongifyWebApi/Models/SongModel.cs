namespace SongifyWebApi.Models
{
    public class SongModel
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTimeOffset ReleasedDate { get; set; }

        public int GenreId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }

    public class SongModelWithGenreName
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public DateTimeOffset ReleasedDate { get; set; }

        public string GenreName { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}
