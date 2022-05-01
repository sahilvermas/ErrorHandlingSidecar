namespace Domain.Models.Response;

public class ErrorResponse
{
    public ErrorResponse()
    {
        ErrorCode = "1";
        Name = "No error found for this code";
    }

    public string ErrorCode { get; set; }
    public string Name { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public bool CanRetry { get; set; } = false;
    public short NoOfRetries { get; set; } = 0;
    public string RequestId { get; set; } = string.Empty;
    public bool PublishToDlq { get; set; } = false;
    public string Category { get; set; } = string.Empty;
}