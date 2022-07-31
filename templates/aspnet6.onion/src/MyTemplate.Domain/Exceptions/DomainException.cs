using System.Runtime.Serialization;

namespace MyTemplate.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public DomainException(string? message, string? paramName) : base(message)
    {
        ParamName = paramName;
    }

    public DomainException(string? message, string? paramName, Exception? innerException) : base(message, innerException)
    {
        ParamName = paramName;
    }

    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public string? ParamName { get; }
}
