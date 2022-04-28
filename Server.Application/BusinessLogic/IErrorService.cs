using Domain.Models.Request;
using Domain.Models.Response;

namespace Server.Application.BusinessLogic;

public interface IErrorService
{
    Task<ErrorResponse> GetErrorResponse(ErrorRequest request, string errorSchemaFilePath);
}