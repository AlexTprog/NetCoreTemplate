using NetCoreTemplate.Application.Abstractions.Messaging;
using NetCoreTemplate.Application.Users.SearchUsers;

namespace NetCoreTemplate.Application.Users.SearchUser
{
    public sealed record SearchUsersQuery() : IQuery<IReadOnlyList<UserResponse>>;
}
