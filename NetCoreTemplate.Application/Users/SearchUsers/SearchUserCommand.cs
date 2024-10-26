using NetCoreTemplate.Application.Abstractions.Messaging;

namespace NetCoreTemplate.Application.Users.SearchUsers;

public record SearchUserCommand() : ICommand<UserResponse[]>;
