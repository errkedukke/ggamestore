namespace Gamestore.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string name, Guid id)
        : base($"{name} ({id}) was not found")
    {
    }
}
