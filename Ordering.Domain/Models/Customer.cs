namespace Ordering.Domain.Models;

public class Customer : Entity<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
}
