namespace MyTemplate.Domain.Exceptions;

[Serializable]
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

    public string? ParamName { get; }
}
