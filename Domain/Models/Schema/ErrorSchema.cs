using System.Runtime.Serialization;

namespace Domain.Models.Schema;

[DataContract]
public class ErrorSchema
{
    [DataMember(Name = "errorCode")] public string ErrorCode { get; set; } = string.Empty;

    [DataMember(Name = "name")] public string Name { get; set; } = string.Empty;

    [DataMember(Name = "errorMessage")] public string ErrorMessage { get; set; } = string.Empty;

    [DataMember(Name = "canRetry")] public bool CanRetry { get; set; }

    [DataMember(Name = "noOfRetries")] public short NoOfRetries { get; set; }

    [DataMember(Name = "requestId")] public string RequestId { get; set; } = string.Empty;

    [DataMember(Name = "publishToDlq")] public bool PublishToDlq { get; set; }

    [DataMember(Name = "category")] public string Category { get; set; } = string.Empty;
}