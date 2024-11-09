using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public class Publisher : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;

    public string HomePage { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
