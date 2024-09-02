namespace SongWebApi.Models
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset ReleasedDate { get; set; }

        // Foreign Key
        public int GenreId { get; set; }

        //public DateTimeOffset CreatedAt { get; set; }
        //public string CreatedBy { get; set; } = "SYSTEM";
        //public DateTimeOffset UpdatedAt { get; set; }
        //public string UpdatedBy { get; set; } = "SYSTEM";
    }

}
