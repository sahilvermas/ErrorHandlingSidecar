using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Models.Schema;
using Server.Application.Utilities;

namespace Server.Application.BusinessLogic;
public class ErrorService : IErrorService
{
    public async Task<ErrorResponse> GetErrorResponse(ErrorRequest request, string errorSchemaFilePath)
    {
        var errorSchema = await GetErrorSchema(errorSchemaFilePath);

        var err = errorSchema?.FirstOrDefault(x => !string.IsNullOrEmpty(x.ErrorCode) && x.ErrorCode.Equals(request.ErrorCode));

        if (err == null) return new ErrorResponse();

        return new ErrorResponse()
        {
            ErrorCode = err.ErrorCode,
            Name = err.Name,
            ErrorMessage = err.ErrorMessage,
            CanRetry = err.CanRetry,
            Category = err.Category,
            NoOfRetries = err.NoOfRetries,
            PublishToDlq = err.PublishToDlq,
            RequestId = err.RequestId
        };
    }

    private static async Task<List<ErrorSchema>?> GetErrorSchema(string errorSchemaFilePath)
    {
        var errorSchema = new List<ErrorSchema>();
        using var reader = new StreamReader(errorSchemaFilePath);
        if (reader.Peek() != 0) errorSchema = FormatUtil.Deserialize<List<ErrorSchema>>(await reader.ReadToEndAsync());
        return errorSchema;
    }
}