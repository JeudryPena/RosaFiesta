namespace Domain.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid ownerId)
        : base($"The owner with the identifier {ownerId} was not found")
    {
    }
}