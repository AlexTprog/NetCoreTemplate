using NetCoreTemplate.Application.Abstractions.Email;
using NetCoreTemplate.Domain.Users;

namespace NetCoreTemplate.Infrastructure;

internal sealed class EmailService : IEmailService
{

    public Task SendAsync(Email recipient, string subject, string body)
    {
        throw new NotImplementedException();
    }
}