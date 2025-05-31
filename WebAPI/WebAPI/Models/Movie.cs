using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string? Genre { get; set; }

    public float Price { get; set; }
}
