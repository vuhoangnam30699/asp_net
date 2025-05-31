using System;
using System.Collections.Generic;

namespace WebApp6.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string? Genre { get; set; }

    public float Price { get; set; }

    public string? Description { get; set; }

    public string? Rating { get; set; }
}
