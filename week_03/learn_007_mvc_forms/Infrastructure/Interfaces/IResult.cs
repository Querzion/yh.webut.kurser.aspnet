namespace Infrastructure.Interfaces;

public interface IResult
{
    bool Success { get; }
    int StatusCode { get; }
    string? ErrorMessage { get; }
    
    public bool IsSuccess => Success;
}