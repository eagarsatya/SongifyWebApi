namespace SongWebApi.Models
{
    public class SongWithGenreModel
    {
        public int SongId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset ReleasedDate { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
