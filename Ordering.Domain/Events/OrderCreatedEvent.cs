using Ordering.Domain.Models;

namespace Ordering.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;
