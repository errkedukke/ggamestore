namespace Gamestore.Application.Features.Categories.Queries
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
