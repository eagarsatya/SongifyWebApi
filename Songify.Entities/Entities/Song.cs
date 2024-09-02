using System;
using System.Collections.Generic;

namespace Songify.Entities.Entities;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public DateTimeOffset ReleasedDate { get; set; }

    public int GenreId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTimeOffset UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
