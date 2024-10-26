using NetCoreTemplate.Application.Abstractions.Clock;

namespace NetCoreTemplate.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.Now;
}
