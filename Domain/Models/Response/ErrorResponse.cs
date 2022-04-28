namespace Domain.Models.Response;

public class ErrorResponse
{
    public string ErrorCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public bool CanRetry { get; set; } = false;
    public short NoOfRetries { get; set; } = 0;
    public string RequestId { get; set; } = string.Empty;
    public bool PublishToDlq { get; set; } = false;
    public string Category { get; set; } = string.Empty;
}