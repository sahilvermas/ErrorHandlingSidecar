using Domain.Models.Request;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Server.Application.BusinessLogic;

namespace Server.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ErrorHandlerController : ControllerBase
{
    private readonly ILogger<ErrorHandlerController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IErrorService _errorService;

    public ErrorHandlerController(ILogger<ErrorHandlerController> logger,
        IConfiguration configuration,
        IErrorService errorService)
    {
        _logger = logger;
        _configuration = configuration;
        _errorService = errorService;
    }

    [HttpGet(Name = "test")]
    public string Get()
    {
        _logger.LogInformation("Test Api Called");
        return "Test api called";
    }

    [HttpPost(Name = "GetErrorResponse")]
    public async Task<ErrorResponse> Post([FromBody] ErrorRequest request)
    {
        _logger.LogInformation($"Error Code: {request.ErrorCode}");

        var errorSchemaFilePath = _configuration.GetValue<string>("ErrorSchemaPath");
        return await _errorService.GetErrorResponse(request, errorSchemaFilePath);
    }
}