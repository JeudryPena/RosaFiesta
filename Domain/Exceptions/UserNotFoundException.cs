namespace Domain.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string ownerId)
        : base($"The owner with the identifier {ownerId} was not found")
    {
    }
}