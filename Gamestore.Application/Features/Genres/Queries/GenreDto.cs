namespace Gamestore.Application.Features.Genres.Queries;

public class GenreDto
{
    public string Name { get; set; } = string.Empty;

    public Guid ParentId { get; set; }
}
