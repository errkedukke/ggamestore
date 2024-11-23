namespace Gamestore.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, Guid id)
        : base($"{name} ({id}) was not found")
    {
    }
}
