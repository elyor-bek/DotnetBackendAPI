using FluentValidation.Results;

namespace DotnetBackendAPI.Validators;

public class ResponseErrors : Exception
{
    public List<ValidationFailure> Errors { get; set; } = new();
}
