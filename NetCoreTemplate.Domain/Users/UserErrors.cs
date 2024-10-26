using NetCoreTemplate.Domain.Abstractions;

namespace NetCoreTemplate.Domain.Users;

public static class UserErrors
{

    public static readonly Error NotFound = new(
        "User.Found",
        "User not exist"
    );

    public static readonly Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Invalid Credentials"
    );

}