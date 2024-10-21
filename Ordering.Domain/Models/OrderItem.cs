namespace Ordering.Domain.Models;

public class OrderItem(Guid orderId, Guid productId, int quantity, decimal price) : Entity<Guid>
{
    public Guid OrderId { get; private set; } = orderId;
    public Guid ProductId { get; private set; } = productId;
    public int Quantity { get; private set; } = quantity;
    public decimal Price { get; private set; } = price;
}