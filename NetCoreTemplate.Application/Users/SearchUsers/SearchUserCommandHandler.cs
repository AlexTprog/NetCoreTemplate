using NetCoreTemplate.Application.Abstractions.Messaging;
using NetCoreTemplate.Domain.Abstractions;
using NetCoreTemplate.Domain.Users;

namespace NetCoreTemplate.Application.Users.SearchUsers;

internal sealed class SearchUserCommandHandler(IUserRepository userRepository)
    : ICommandHandler<SearchUserCommand, UserResponse[]>
{

    public async Task<Result<UserResponse[]>> Handle(SearchUserCommand request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAll();

        if (users == null)
        {
            return Result.Failure<UserResponse[]>(UserErrors.NotFound);
        }

        var response = users.Select(x => new UserResponse
        {
            Id = x.Id,
            Email = x.Email?.Value,
            LastName = x.LastName?.Value,
            Name = x.Name?.Value
        }).ToArray();

        return Result.Success(response);
    }
}
