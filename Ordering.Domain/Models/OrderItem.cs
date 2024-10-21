namespace Ordering.Domain.Models;

public class OrderItem(Guid orderId, Guid productId, int quantity, decimal price) : Entity<Guid>
{
    public Guid OrderId { get; set; } = orderId;
    public Guid ProductId { get; set; } = productId;
    public int Quantity { get; set; } = quantity;
    public decimal Price { get; set; } = price;
}