namespace Ordering.Domain.Models;

public class Customer : Entity<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
}
