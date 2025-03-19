namespace TaskManagement.Application.Exceptions;

public class ValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; } = null!;

    public ValidationException(Dictionary<string, string[]> errors)
        : base("Validation errors occurrend.")
    {
        Errors = errors;
    }
}