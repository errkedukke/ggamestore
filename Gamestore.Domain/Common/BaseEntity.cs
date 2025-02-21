namespace Gamestore.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public DateTime DateCreated { get; set; } = DateTime.Now;

    public DateTime? DateModified { get; set; } = null;

    public bool IsDeleted { get; set; }
}
