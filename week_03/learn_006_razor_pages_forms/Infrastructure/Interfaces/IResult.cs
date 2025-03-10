namespace Infrastructure.Interfaces;

public class IResult
{
    bool Success { get; }
    int StatusCode { get; }
    string? ErrorMessage { get; }
}