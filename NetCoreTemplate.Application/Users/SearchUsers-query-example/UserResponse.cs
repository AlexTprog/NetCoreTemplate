namespace NetCoreTemplate.Application.Users.SearchUsers;

public sealed class UserResponse
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? LastName { get; init; }

    public string? Email { get; init; }

}
