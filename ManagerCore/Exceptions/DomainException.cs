namespace ManagerCore.Exceptions;

public class DomainException : Exception
{
    internal List<string> _errors;

    public IReadOnlyCollection<string> Errors => _errors;

    public DomainException(List<string> errors)
    {
        _errors = errors;
    }

    public DomainException(string message, List<string> errors) : base(message)
    {
        _errors = errors;
    }
    
    public DomainException(string message) : base(message)
    {
    }
    
    public DomainException(string message, Exception innerException, List<string> errors) : base(message, innerException)
    {
    }
}