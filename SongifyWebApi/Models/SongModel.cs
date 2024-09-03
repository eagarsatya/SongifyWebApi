namespace SongifyWebApi.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset ReleasedDate { get; set; }
        public int GenreId { get; set; }
    }
}
