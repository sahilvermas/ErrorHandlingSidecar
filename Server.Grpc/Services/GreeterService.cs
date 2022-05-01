using Grpc.Core;
using Server.Application.BusinessLogic;

namespace Server.Grpc.Services;

public class ErrorHandlerService : ErrorHandler.ErrorHandlerBase
{
    private readonly ILogger<ErrorHandlerService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IErrorService _errorService;
    public ErrorHandlerService(ILogger<ErrorHandlerService> logger,
        IConfiguration configuration,
        IErrorService errorService)
    {
        _logger = logger;
        _configuration = configuration;
        _errorService = errorService;
    }

    public override async Task<ErrorResponse> GetErrorResponse(ErrorRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Error Code {request.ErrorCode}");

        var errorSchemaFilePath = _configuration.GetValue<string>("ErrorSchemaPath");

        var errorRequest = new Domain.Models.Request.ErrorRequest { ErrorCode = request.ErrorCode };
        var response = await _errorService.GetErrorResponse(errorRequest, errorSchemaFilePath);

        var errorResponse = new ErrorResponse
        {
            ErrorCode = response.ErrorCode,
            ErrorMessage = response.ErrorMessage,
            CanRetry = response.CanRetry,
            Category = response.Category,
            Name = response.Name,
            NoOfRetries = response.NoOfRetries,
            PublishToDlq = response.PublishToDlq,
            RequestId = response.RequestId
        };


        return errorResponse;
    }
}