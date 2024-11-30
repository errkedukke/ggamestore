namespace Gamestore.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string name, Guid id)
        : base($"{name} ({id}) was not found")
    {
    }
}
