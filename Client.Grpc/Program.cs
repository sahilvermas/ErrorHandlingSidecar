
using Grpc.Core;
using Grpc.Net.Client;
using Server.Grpc;

var port = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "5000";
var serverAddress = $"http://localhost:{port}";
var channel = GrpcChannel.ForAddress(serverAddress);
var client = new ErrorHandler.ErrorHandlerClient(channel);

var request = new ErrorRequest { ErrorCode = "1002" };
var metadata = new Metadata { { "dapr-app-id", "eh-grpc-server" } };
var response = await client.GetErrorResponseAsync(request, metadata);

Console.WriteLine("###################################");
Console.WriteLine(response);
Console.WriteLine("###################################");

