using NetCoreTemplate.Application.Abstractions.Data;
using NetCoreTemplate.Application.Abstractions.Messaging;
using NetCoreTemplate.Application.Users.SearchUser;
using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Application.Users.SearchUsers;

internal class SearchUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IQueryHandler<SearchUsersQuery, IReadOnlyList<UserResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

    //TODO generic paginator
    public Task<Result<IReadOnlyList<UserResponse>>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
