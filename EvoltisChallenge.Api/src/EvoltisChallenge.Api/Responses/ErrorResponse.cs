namespace EvoltisChallenge.Api.Responses;

public class ErrorResponse(string message, string[]? errors = null)
{
    public string Message { get; } = message;
    public string[] Errors { get; } = errors ?? [];
}