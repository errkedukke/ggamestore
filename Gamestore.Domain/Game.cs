﻿using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class Game : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }

    public required Category Category { get; set; }

    [ForeignKey(nameof(Genre))]
    public Guid GenreId { get; set; }

    public required Genre Genre { get; set; }

    [ForeignKey(nameof(Publisher))]
    public Guid PublisherId { get; set; }

    public required Publisher Publisher { get; set; }

    public Platform Platform { get; set; }

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int Views { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageKey { get; set; } = string.Empty;
}