namespace NetCoreTemplate.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime currentTime { get; }
}