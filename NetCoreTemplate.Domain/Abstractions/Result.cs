using System.Diagnostics.CodeAnalysis;

namespace NetCoreTemplate.Domain.Abstractions;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
    {
        return new(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new(false, error);
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new(value, true, Error.None);
    }

    public static Result<TValue> Failure<TValue>(Error error)
    {
        return new(default, false, error);
    }

    public static Result<TValue> Create<TValue>(TValue? value)
    {

        return value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    }

}

public class Result<TValue> : Result
{

    [NotNull]
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("El resultado del valor de error no es admisible");

    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue value)
    {
        return Create(value);
    }

}