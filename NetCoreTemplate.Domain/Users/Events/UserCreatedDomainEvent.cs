using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;